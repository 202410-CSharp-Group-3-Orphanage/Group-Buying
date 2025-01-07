import random
import pymssql
import pyodbc

try:
    # 宣告一個含有MS SQL Server連線參數的連線
    sqlconn = pymssql.connect(
        # server=r"localhost\sql2022",
        server="localhost",
        user="sa5",
        password="sa5",
        database="GroupBuying",
        # appname="sql2022",
    )
except:  # noqa: E722
    # 設定連線字串
    connection_string = (
        "DRIVER={ODBC Driver 17 for SQL Server};"  # 確保已安裝對應的 ODBC 驅動程式
        # "SERVER=localhost\\sql2022;"  # 伺服器名稱，若埠號非預設，需指定為 localhost,1433
        "SERVER=localhost;"  # 伺服器名稱，若埠號非預設，需指定為 localhost,1433
        "DATABASE=GroupBuying;"  # 資料庫名稱
        "UID=sa5;"  # 使用者名稱
        "PWD=sa5;"  # 密碼
    )
    sqlconn = pyodbc.connect(connection_string)


def get_random_ids(table, column):
    """從資料庫中隨機取得指定表和列的值"""
    with sqlconn.cursor() as cursor:
        cursor.execute(f"SELECT TOP (10) {column} FROM {table} ORDER BY NEWID()")
        return [row[0] for row in cursor.fetchall()]


def execute_sql(sql):
    """執行SQL語句"""
    with sqlconn.cursor() as cursor:
        cursor.execute(sql)
        sqlconn.commit()


def get_table_data(table, columns, where_clause=None):
    """從資料庫中隨機取得指定表和欄位的值，可選擇加入 WHERE 條件"""
    with sqlconn.cursor() as cursor:
        query = f"SELECT {', '.join(columns)} FROM {table}"
        if where_clause:
            query += f" WHERE {where_clause}"
        cursor.execute(query)
        return [tuple(row) for row in cursor.fetchall()]


def get_random_product():
    """隨機從 Products 表中取得一個 ProductId 和其對應的價格"""
    product_data = get_table_data("[GroupBuying].[dbo].[Products]", ["[Id]", "[Price]"])

    if not product_data:
        raise ValueError(
            "Product data is empty. Ensure the Products table contains data."
        )

    return random.choice(product_data)


def get_random_member():
    """隨機從 Members 表中取得一個 MemberId"""
    member_data = get_table_data("[GroupBuying].[dbo].[Members]", ["[Id]"])

    if not member_data:
        raise ValueError(
            "Member data is empty. Ensure the Members table contains data."
        )

    return random.choice(member_data)[0]


def get_random_group_buying():
    """隨機從 GroupBuyings 表中取得一個 GroupBuyingId 和價格，條件是 Enabled 為 1"""
    group_buying_data = get_table_data(
        "[GroupBuying].[dbo].[GroupBuyings]", ["[Id]", "[Price]"], "[Enabled] = 1"
    )

    if not group_buying_data:
        raise ValueError("GroupBuying data is empty or no enabled records found.")

    return random.choice(group_buying_data)


if __name__ == "__main__":
    product_id, original_price = get_random_product()
    print(product_id, original_price)
