-- Carts
EXEC sp_addextendedproperty 'MS_Description', N'數量', 'SCHEMA', 'dbo', 'TABLE', 'Carts', 'COLUMN', 'Quantity'

-- Categories
EXEC sp_addextendedproperty 'MS_Description', N'分類名稱', 'SCHEMA', 'dbo', 'TABLE', 'Categories', 'COLUMN', 'Name'
EXEC sp_addextendedproperty 'MS_Description', N'顯示順序', 'SCHEMA', 'dbo', 'TABLE', 'Categories', 'COLUMN', 'DisplayOrder'

-- Departments 
EXEC sp_addextendedproperty 'MS_Description', N'部門名稱', 'SCHEMA', 'dbo', 'TABLE', 'Departments', 'COLUMN', 'Name'

-- Employees
EXEC sp_addextendedproperty 'MS_Description', N'帳號', 'SCHEMA', 'dbo', 'TABLE', 'Employees', 'COLUMN', 'Account'
EXEC sp_addextendedproperty 'MS_Description', N'加密後密碼', 'SCHEMA', 'dbo', 'TABLE', 'Employees', 'COLUMN', 'EncryptedPassword'
EXEC sp_addextendedproperty 'MS_Description', N'姓名', 'SCHEMA', 'dbo', 'TABLE', 'Employees', 'COLUMN', 'Name'

-- GroupBuyings
EXEC sp_addextendedproperty 'MS_Description', N'團購價格', 'SCHEMA', 'dbo', 'TABLE', 'GroupBuyings', 'COLUMN', 'Price'
EXEC sp_addextendedproperty 'MS_Description', N'最小成團人數', 'SCHEMA', 'dbo', 'TABLE', 'GroupBuyings', 'COLUMN', 'MinimumGroupSize'
EXEC sp_addextendedproperty 'MS_Description', N'團購說明', 'SCHEMA', 'dbo', 'TABLE', 'GroupBuyings', 'COLUMN', 'Description'
EXEC sp_addextendedproperty 'MS_Description', N'開始時間', 'SCHEMA', 'dbo', 'TABLE', 'GroupBuyings', 'COLUMN', 'StartDate'
EXEC sp_addextendedproperty 'MS_Description', N'結束時間', 'SCHEMA', 'dbo', 'TABLE', 'GroupBuyings', 'COLUMN', 'EndDate'
EXEC sp_addextendedproperty 'MS_Description', N'狀態(0:未開始,1:進行中,2:已結束)', 'SCHEMA', 'dbo', 'TABLE', 'GroupBuyings', 'COLUMN', 'Status'

-- Members
EXEC sp_addextendedproperty 'MS_Description', N'帳號', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'Account'
EXEC sp_addextendedproperty 'MS_Description', N'加密後密碼', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'EncryptedPassword'
EXEC sp_addextendedproperty 'MS_Description', N'姓名', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'Name'
EXEC sp_addextendedproperty 'MS_Description', N'性別(0:女,1:男)', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'Gender'
EXEC sp_addextendedproperty 'MS_Description', N'電子信箱', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'Email'
EXEC sp_addextendedproperty 'MS_Description', N'手機號碼', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'Phone'
EXEC sp_addextendedproperty 'MS_Description', N'生日', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'Birthday'
EXEC sp_addextendedproperty 'MS_Description', N'狀態(0:停用,1:啟用)', 'SCHEMA', 'dbo', 'TABLE', 'Members', 'COLUMN', 'Status'

-- Orders
EXEC sp_addextendedproperty 'MS_Description', N'成交價格', 'SCHEMA', 'dbo', 'TABLE', 'Orders', 'COLUMN', 'Price'
EXEC sp_addextendedproperty 'MS_Description', N'數量', 'SCHEMA', 'dbo', 'TABLE', 'Orders', 'COLUMN', 'Quantity'
EXEC sp_addextendedproperty 'MS_Description', N'運送方式(1:超商,2:宅配)', 'SCHEMA', 'dbo', 'TABLE', 'Orders', 'COLUMN', 'ShippingMethod'
EXEC sp_addextendedproperty 'MS_Description', N'運送地址', 'SCHEMA', 'dbo', 'TABLE', 'Orders', 'COLUMN', 'ShippingAddress'
EXEC sp_addextendedproperty 'MS_Description', N'訂單狀態(0:已取消,1:處理中,2:已完成)', 'SCHEMA', 'dbo', 'TABLE', 'Orders', 'COLUMN', 'Status'
EXEC sp_addextendedproperty 'MS_Description', N'付款狀態(0:未付款,1:已付款)', 'SCHEMA', 'dbo', 'TABLE', 'Orders', 'COLUMN', 'PaymentStatus'
EXEC sp_addextendedproperty 'MS_Description', N'運送狀態(0:未出貨,1:已出貨,2:已送達)', 'SCHEMA', 'dbo', 'TABLE', 'Orders', 'COLUMN', 'DeliveryStatus'

-- Products
EXEC sp_addextendedproperty 'MS_Description', N'商品名稱', 'SCHEMA', 'dbo', 'TABLE', 'Products', 'COLUMN', 'Name'
EXEC sp_addextendedproperty 'MS_Description', N'原價', 'SCHEMA', 'dbo', 'TABLE', 'Products', 'COLUMN', 'Price'
EXEC sp_addextendedproperty 'MS_Description', N'主要圖片', 'SCHEMA', 'dbo', 'TABLE', 'Products', 'COLUMN', 'MainImage'
EXEC sp_addextendedproperty 'MS_Description', N'商品資訊', 'SCHEMA', 'dbo', 'TABLE', 'Products', 'COLUMN', 'Info'

-- Shops
EXEC sp_addextendedproperty 'MS_Description', N'帳號', 'SCHEMA', 'dbo', 'TABLE', 'Shops', 'COLUMN', 'Account'
EXEC sp_addextendedproperty 'MS_Description', N'加密後密碼', 'SCHEMA', 'dbo', 'TABLE', 'Shops', 'COLUMN', 'EncryptedPassword'
EXEC sp_addextendedproperty 'MS_Description', N'商店名稱', 'SCHEMA', 'dbo', 'TABLE', 'Shops', 'COLUMN', 'Name'
EXEC sp_addextendedproperty 'MS_Description', N'身分證字號', 'SCHEMA', 'dbo', 'TABLE', 'Shops', 'COLUMN', 'IdentityCard'
EXEC sp_addextendedproperty 'MS_Description', N'頭像', 'SCHEMA', 'dbo', 'TABLE', 'Shops', 'COLUMN', 'Avatar'
EXEC sp_addextendedproperty 'MS_Description', N'商店地址', 'SCHEMA', 'dbo', 'TABLE', 'Shops', 'COLUMN', 'Address'
EXEC sp_addextendedproperty 'MS_Description', N'狀態(0:停用,1:啟用)', 'SCHEMA', 'dbo', 'TABLE', 'Shops', 'COLUMN', 'Status'