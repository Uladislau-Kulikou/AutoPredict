import unicodedata

def normalize(text: str) -> str:
    """Removes only diacritical marks (umlauts, accents, etc.), leaving all other characters unchanged."""
    nfkd = unicodedata.normalize('NFKD', text)
    clean = ''.join(ch for ch in nfkd if not unicodedata.category(ch).startswith('M'))
    return clean

