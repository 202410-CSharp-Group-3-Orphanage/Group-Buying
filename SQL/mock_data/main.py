from BaseSQLc import execute_sql
import mock

if __name__ == "__main__":
    # delete all
    execute_sql(mock.delete_all())

    # categories
    execute_sql(mock.categories())

    # members
    for _ in range(100):
        execute_sql(mock.members())

    # shops
    for _ in range(50):
        execute_sql(mock.shops())

    # products
    for _ in range(500):
        execute_sql(mock.products())

    # product_images
    for _ in range(1000):
        execute_sql(mock.product_images())

    # wishes
    for _ in range(1000):
        execute_sql(mock.wishes())

    # group_buyings
    for _ in range(300):
        execute_sql(mock.group_buyings())

    # orders
    for _ in range(100):
        execute_sql(mock.orders())

    # carts
    for _ in range(100):
        execute_sql(mock.carts())
