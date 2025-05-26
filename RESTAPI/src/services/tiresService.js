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
  return await prisma.tires.delete({
    where: { id }
  });
};

export const getPaginatedTires = async (page =1, size =10) =>{
  const skip = (page -1)* size;

  const [tires, total] = await Promise.all([
    prisma.tires.findMany({
      skip,
      take: size,
    }),
    prisma.tires.count(),
  ]);

  return {
    data: tires,
    total,
    page,
    size,
    totalPage: Math.ceil(total/size),
  };
}