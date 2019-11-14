using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Archivos;
using EntidadesAbstractas;
using Clases_instanciables;

namespace Test_unitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExcepcionNacionalidad()
        {
            try
            {
                Alumno a1=new Alumno(1, "Juana", "Martinez", "0",
               EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
               Alumno.EEstadoCuenta.Deudor);
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(Excepciones.NacionalidadInvalidaException));
             }
        }

        [TestMethod]
        public void TestExceptionAlumnoRepetido()
        {
            try
            {
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "0",
               EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
               Alumno.EEstadoCuenta.Deudor);
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
                Universidad u1 = new Universidad();

                u1 += a1;
                u1 += a2;
                u1 += a3;
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(Excepciones.NacionalidadInvalidaException));
            }
        }
        [TestMethod]
        public void TestExceptionSinProfesor()
        {
            try
            {
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
                Alumno a2 = new Alumno(2, "José", "Gutierrez", "12234356",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
                Universidad u1 = new Universidad();

                u1 += a1;
                u1 += a2;
                u1 += Universidad.EClases.Legislacion;
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(Excepciones.SinProfesorException));
            }
        }
        [TestMethod]
        public void TestExceptionArchivos()
        {
            try
            {
                Universidad u1 = new Universidad();
                Universidad.Leer(u1);
            }
            catch (ArchivosException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }
        }
        [TestMethod]
        public void TestValidarInt()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
        EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
        Alumno.EEstadoCuenta.Becado);

            Assert.IsInstanceOfType(a1.DNI, typeof(int));
        }
        [TestMethod]
        public void TestClasesNotNull()
        {
            Alumno a1 = new Alumno();
            Profesor p1 = new Profesor();
            Universidad u1 = new Universidad();
            
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(p1.Nombre);
            Assert.IsNotNull(u1.Alumnos);
        }
    }
}
