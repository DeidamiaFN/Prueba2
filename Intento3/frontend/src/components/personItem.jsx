import PropTypes from "prop-types";

export default function PersonItem({ Nombre, PeronaId, FechaNacimiento }) {
  return (
    <div className="w-1/2 flex flex-col justify-center bg-purple-500 rounded-md">
      <p>{Nombre}</p>
      <p>{PeronaId}</p>
      <p>{FechaNacimiento}</p>
    </div>
  );
}

PersonItem.propTypes = {
  Nombre: PropTypes.string,
  PeronaId: PropTypes.string,
  FechaNacimiento: PropTypes.string,
};
