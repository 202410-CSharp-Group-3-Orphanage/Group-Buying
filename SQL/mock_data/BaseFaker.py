from faker import Faker
import re

myfaker = Faker("zh_TW")


def get_phone():
    """
    docstring
    """
    while True:
        phone_number = myfaker.phone_number().replace("-", "")[:10]
        if validate_phone_number(phone_number):
            return phone_number


def validate_phone_number(phone_number):
    pattern = r"^09\d{8}$"
    if re.match(pattern, phone_number):
        return True
    else:
        return False


def remove_special_characters(text):
    # 使用正則表達式，保留字母、數字和中文，其它字符移除
    cleaned_text = re.sub(r"[^a-zA-Z0-9\u4e00-\u9fa5]", "", text)
    return cleaned_text


if __name__ == "__main__":
    s = myfaker.sentence(nb_words=200)
    print(s)
