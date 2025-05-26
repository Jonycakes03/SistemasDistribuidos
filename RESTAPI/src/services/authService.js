import jwt from 'jsonwebtoken';
import bcrypt from 'bcryptjs';

const fakeUser = {
  id: '123',
  email: 'admin@llantas.com',
  passwordHash: bcrypt.hashSync('admin123', 10), 
};

const JWT_SECRET = process.env.JWT_SECRET || 'supersecreto';

export const login = async ({ email, password }) => {
  if (email !== fakeUser.email) throw new Error('Usuario no encontrado');

  const valid = await bcrypt.compare(password, fakeUser.passwordHash);
  if (!valid) throw new Error('Contraseña incorrecta');

  const token = jwt.sign({ id: fakeUser.id, email }, JWT_SECRET, {
    expiresIn: '2h',
  });

  return { token };
};
