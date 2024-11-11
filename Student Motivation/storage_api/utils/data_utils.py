def validate_user_data(email, password):
    # Example validation function
    if not email or not password:
        return False, "Email and password are required"
    if len(password) < 6:
        return False, "Password must be at least 6 characters long"
    return True, ""