

import hashlib

def hash256_str(plain_text: str) -> str:
    """
    docstring
    """
    encoded_text = plain_text.encode("utf-8")
    return hashlib.sha256(encoded_text).hexdigest()