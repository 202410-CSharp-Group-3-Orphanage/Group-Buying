import random
import uuid
from BaseFaker import get_phone, myfaker, remove_special_characters
from BaseHash import hash256_str
from BaseSQLc import (
    get_random_group_buying,
    get_random_ids,
    get_random_member,
    get_random_product,
)


def delete_all():
    # 從最後一個表開始刪除，以避免外鍵約束錯誤
    return """
DELETE FROM [GroupBuying].[dbo].[Carts];
DELETE FROM [GroupBuying].[dbo].[Orders];
DELETE FROM [GroupBuying].[dbo].[GroupBuyings];
DELETE FROM [GroupBuying].[dbo].[Wishes];
DELETE FROM [GroupBuying].[dbo].[ProductImages];
DELETE FROM [GroupBuying].[dbo].[Products];
DELETE FROM [GroupBuying].[dbo].[Shops];
DELETE FROM [GroupBuying].[dbo].[Members];
DELETE FROM [GroupBuying].[dbo].[Categories];
"""


def categories():
    return """
INSERT INTO [GroupBuying].[dbo].[Categories] 
      ([Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt])
VALUES 
      (N'3C', 1, 1, GETDATE(), GETDATE()),
      (N'周邊', 2, 1, GETDATE(), GETDATE()),
      (N'筆電', 3, 1, GETDATE(), GETDATE()),
      (N'通訊', 4, 1, GETDATE(), GETDATE()),
      (N'數位', 5, 1, GETDATE(), GETDATE()),
      (N'家電', 6, 1, GETDATE(), GETDATE()),
      (N'日用', 7, 1, GETDATE(), GETDATE()),
      (N'母嬰', 8, 1, GETDATE(), GETDATE()),
      (N'食品', 9, 1, GETDATE(), GETDATE()),
      (N'生活', 10, 1, GETDATE(), GETDATE()),
      (N'居家', 11, 1, GETDATE(), GETDATE()),
      (N'休閒', 12, 1, GETDATE(), GETDATE()),
      (N'保健', 13, 1, GETDATE(), GETDATE()),
      (N'美妝', 14, 1, GETDATE(), GETDATE()),
      (N'時尚', 15, 1, GETDATE(), GETDATE()),
      (N'書店', 16, 1, GETDATE(), GETDATE()),
      (N'其他', 17, 1, GETDATE(), GETDATE());
      """


def members():
    account = myfaker.user_name().lower()
    # sha256
    encrypted_password = hash256_str("123456")
    name = myfaker.name()
    gender = random.choice([0, 1])
    email = account + random.choice(["@gmail.com", "@icloud.com", "@hotmail.com"])
    phone = get_phone()
    birthday = myfaker.date_of_birth()
    status = random.choice(
        [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
    )
    is_confirmed = random.choice(
        [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
    )
    comfirm_code = (
        f"'{str(uuid.uuid4()).replace('-', '')}'" if is_confirmed == 0 else "NULL"
    )
    created_at = myfaker.date_time_this_year()
    updated_at = created_at
    return f"""
INSERT INTO [GroupBuying].[dbo].[Members] 
        ([Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt])
VALUES 
        ('{account}', '{encrypted_password}', N'{name}', {gender}, '{email}', '{phone}', '{birthday}', {status}, {is_confirmed}, {comfirm_code}, '{created_at}', '{updated_at}');
"""


def shops():
    account = myfaker.user_name()
    # sha256 密碼加密
    encrypted_password = hash256_str("123456")
    name = remove_special_characters(myfaker.company())
    identity_card = random.choice(
        [
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
        ]
    ) + "".join(random.choices("0123456789", k=9))  # 模擬 10 位數字身份證號碼
    avatar = myfaker.image_url()
    address = myfaker.address().replace("\n", " ")
    status = random.choice([0, 1])
    created_at = myfaker.date_time_this_year()
    updated_at = created_at

    return f"""
INSERT INTO [GroupBuying].[dbo].[Shops] 
        ([Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt])
VALUES 
        ('{account}', '{encrypted_password}', N'{name}', '{identity_card}', '{avatar}', N'{address}', {status}, '{created_at}', '{updated_at}');
"""


def products():
    shop_ids = get_random_ids("[GroupBuying].[dbo].[Shops]", "[Id]")
    category_ids = get_random_ids("[GroupBuying].[dbo].[Categories]", "[Id]")

    if not shop_ids or not category_ids:
        raise ValueError(
            "Shop IDs or Category IDs are empty. Ensure the database contains data in the Shops and Categories tables."
        )

    shop_id = random.choice(shop_ids)
    category_id = random.choice(category_ids)
    name = myfaker.word().capitalize() + "產品"
    price = round(random.uniform(10, 10000), 0)  # 隨機生成價格，範圍 10~1000
    info = myfaker.sentence(nb_words=200)
    created_at = myfaker.date_time_this_year()
    updated_at = created_at

    return f"""
INSERT INTO [GroupBuying].[dbo].[Products] 
        ([ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt])
VALUES 
        ({shop_id}, {category_id}, N'{name}', {price}, N'{info}', '{created_at}', '{updated_at}');
"""


def product_images():
    product_ids = get_random_ids("[GroupBuying].[dbo].[Products]", "[Id]")

    if not product_ids:
        raise ValueError(
            "Product IDs are empty. Ensure the database contains data in the Products table."
        )
    product_id = random.choice(product_ids)
    path = myfaker.image_url()
    created_at = myfaker.date_time_this_year()
    updated_at = created_at
    return f"""
INSERT INTO [GroupBuying].[dbo].[ProductImages] 
        ([ProductId], [Path], [CreatedAt], [UpdatedAt])
VALUES 
        ({product_id}, '{path}', '{created_at}', '{updated_at}');
"""


def wishes():
    member_ids = get_random_ids("[GroupBuying].[dbo].[Members]", "[Id]")
    product_ids = get_random_ids("[GroupBuying].[dbo].[Products]", "[Id]")

    if not member_ids or not product_ids:
        raise ValueError(
            "Member IDs or Product IDs are empty. Ensure the database contains data in the Members and Products tables."
        )

    member_id = random.choice(member_ids)
    product_id = random.choice(product_ids)
    created_at = myfaker.date_time_this_year()
    updated_at = created_at

    return f"""
INSERT INTO [GroupBuying].[dbo].[Wishes] 
        ([MemberId], [ProductId], [CreatedAt], [UpdatedAt])
VALUES 
        ({member_id}, {product_id}, '{created_at}', '{updated_at}');
"""


def group_buyings():
    product_id, original_price = get_random_product()
    discount = random.uniform(0.5, 0.9)  # 隨機生成 5~9 折折扣
    discounted_price = round(original_price * discount, 2)
    minimum_group_size = random.randint(20, 100)
    description = myfaker.text(max_nb_chars=200)
    start_date = myfaker.date_this_year()
    end_date = myfaker.date_between(start_date=start_date)
    enabled = random.choice(
        [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
    )  # 隨機啟用狀態
    created_at = myfaker.date_time_this_year()
    updated_at = created_at

    return f"""
INSERT INTO [GroupBuying].[dbo].[GroupBuyings] 
        ([ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt])
VALUES 
        ({product_id}, {discounted_price}, {minimum_group_size}, N'{description}', '{start_date}', '{end_date}', {enabled}, '{created_at}', '{updated_at}');
"""


def orders():
    member_id = get_random_member()
    group_buying_id, price = get_random_group_buying()
    quantity = random.randint(1, 100)  # 隨機生成數量
    shipping_method = 1
    # shipping_address = "無"
    status = random.choice([0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1])
    payment_status = 0
    delivery_status = 0
    created_at = myfaker.date_time_this_year()
    updated_at = created_at

    return f"""
INSERT INTO [GroupBuying].[dbo].[Orders] 
        ([MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt])
VALUES 
        ({member_id}, {group_buying_id}, {price}, {quantity}, '{shipping_method}', NULL, '{status}', '{payment_status}', '{delivery_status}', '{created_at}', '{updated_at}');
"""


def carts():
    """Generate random cart data for insertion"""
    member_id = get_random_member()
    group_buying_id, _ = get_random_group_buying()  # We don't need price for carts
    quantity = random.randint(1, 100)  # Assuming smaller quantities for cart items
    created_at = myfaker.date_time_this_year()
    updated_at = created_at

    return f"""
    INSERT INTO [GroupBuying].[dbo].[Carts]
    ([MemberId], [GroupBuyingId], [Quantity], [CreatedAt], [UpdatedAt])
    VALUES
    ({member_id}, {group_buying_id}, {quantity}, '{created_at}', '{updated_at}');
    """
