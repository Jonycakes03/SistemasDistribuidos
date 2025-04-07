import { PrismaClient } from '@prisma/client';
const prisma = new PrismaClient();


export const getAllTires = async () => {
  return await prisma.tires.findMany();
};


export const getTiresById = async (id) => {
  return await prisma.tires.findUnique({
    where: { id }
  });
};


export const createTires = async (data) => {
  return await prisma.tires.create({
    data
  });
};


export const updateTires = async (id, data) => {
  return await prisma.tires.update({
    where: { id },
    data
  });
};


export const deleteTires = async (id) => {
  return await prisma.llantas.delete({
    where: { id }
  });
};
