from flask import Flask, request, jsonify
from models import db, User

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///database.db'
db.init_app(app)

@app.route('/user', methods=['POST'])
def create_user():
    data = request.json
    user = User(email=data['email'], password=data['password'])
    db.session.add(user)
    db.session.commit()
    return jsonify({"message": "User created"}), 201

@app.route('/user/<email>', methods=['GET'])
def get_user(email):
    user = User.query.filter_by(email=email).first()
    if user:
        return jsonify({'email': user.email, 'coins': user.coins, 'character_power': user.character_power})
    return jsonify({"message": "User not found"}), 404

if __name__ == '__main__':
    app.run(debug=True)