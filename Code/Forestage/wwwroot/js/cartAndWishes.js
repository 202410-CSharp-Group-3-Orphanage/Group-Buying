export const handleAddToCart = async (productId, quantity) => {
    const userConfirmed = await Swal.fire({
        title: '加入購物車',
        text: '是否將此商品加入購物車？',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: '是',
        cancelButtonText: '否',
    });

    if (userConfirmed.isConfirmed) {
        try {
            const response = await fetch(`/api/CartApi/AddItem`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ productId: productId, quantity: quantity }),
                redirect: 'manual', // 禁止自動重定向，手動處理 302 重定向
            });

            if (response.type === "opaqueredirect") {
                // 檢查是否為 302 重定向，並跳轉至登入頁面
                const currentUrl = encodeURIComponent(window.location.pathname + window.location.search); // 編碼目前頁面網址
                const loginUrl = `/Members/Login?ReturnUrl=${currentUrl}`; // 建立帶有 returnUrl 的登入網址

                await Swal.fire({
                    title: '錯誤',
                    text: '請先登入會員！',
                    icon: 'error',
                    confirmButtonText: '好的',
                }).then(() => {
                    // 彈窗關閉後進行頁面跳轉
                    window.location.href = loginUrl;
                });
                return; // 不再繼續執行後續程式碼
            }

            if (response.ok) {
                await Swal.fire({
                    title: '成功',
                    text: '商品已加入購物車！',
                    icon: 'success',
                    confirmButtonText: '好的',
                });
            } else {
                throw new Error('Failed to add item to cart.');
            }
        } catch (error) {
            await Swal.fire({
                title: '錯誤',
                text: '無法加入購物車，請稍後再試。',
                icon: 'error',
                confirmButtonText: '好的',
            });
        }
    }
};


export const handleAddToWishes = async (productId) => {
    const userConfirmed = await Swal.fire({
        title: '加入願望清單',
        text: '是否將此商品加入願望清單？',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: '是',
        cancelButtonText: '否',
    });

    if (userConfirmed.isConfirmed) {
        try {
            const response = await fetch(`/Wishes/AddItem/${productId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ quantity: 1 }), // 假設願望清單不需要數量
            });

            if (response.ok) {
                await Swal.fire({
                    title: '成功',
                    text: '商品已加入願望清單！',
                    icon: 'success',
                    confirmButtonText: '好的',
                });
            } else {
                throw new Error('Failed to add item to wishes.');
            }
        } catch (error) {
            await Swal.fire({
                title: '錯誤',
                text: '無法加入願望清單，請稍後再試。',
                icon: 'error',
                confirmButtonText: '好的',
            });
        }
    }
};
// 在 cartAndWishes.js 中設置全局變數
window.handleAddToCart = handleAddToCart;
window.handleAddToWishes = handleAddToWishes;
