import { Form, Formik } from "formik";
import { createUser } from "../services/PersonService";
import InputField from "../components/InputFile";

export default function Formulario()
{
    const submit = async (data)=>{
        console.log(data)
        try {
            await createUser(data)
        } catch(error)
        {
            console.error(error)
        }
       
    }
    return(
        <div>
            <Formik initialValues={{nombre:"", fechaNacimiento:""}} onSubmit={(values)=>{submit(values)}}>
                <Form>
                    <InputField name="nombre" type="text" text="Nombre de Autor" placeholder="Ingrese Nombre"/>
                    <InputField name="fechaNacimiento" type="date" text="fecha" />
                    <button type="submit">
                        submit
                    </button>
                </Form>
            </Formik>
        </div>
    )
}