import { useEffect, useState } from "react";
import { getPeople } from "../services/PersonService";
import PersonItem from "../components/personItem";

export default function PersonsPage() {
  const [people, setPeople] = useState([]);

  useEffect(() => {
    const fetchPeople = async() => {
      try {
        const userList = await getPeople();
        setPeople(userList);
      } catch (error) {
        console.error(error);
      }
    }

    fetchPeople();

  }, []);

  return (
    <div className="w-full space-y-5">
      {people.map((person, index) => (
        <PersonItem
          key={index}
          Nombre={person.nombre}
          FechaNacimiento={person.fechaNacimiento}
          PeronaId={person.peronaId}
        />
      ))}
    </div>
  );
}
