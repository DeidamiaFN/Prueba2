import axios from "axios";

export const personAPI = axios.create({
  baseURL: "http://localhost:5290/api/PersonaControllers",
});

export async function getPeople() {
  try {
    const response = await personAPI.get();
    return response.data;
  } catch (error) {
    throw new Error(
      error.response?.data?.message || "Error al conseguir los usuarios"
    );
  }
}

export async function createUser(user) {
  try {
    const response = await personAPI.post("", user);
    return response.data;
  } catch (error){
    throw new Error(
      error.response?.data?.message || "Error al añadir"
    );
  }
}
