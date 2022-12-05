using AutoMapper;
using mediciones_electricas_api.Dtos.Empleados;
using mediciones_electricas_api.Dtos.Equipos;
using mediciones_electricas_api.Dtos.LineaProduccion;
using mediciones_electricas_api.Dtos.Login;
using mediciones_electricas_api.Dtos.Modelos;
using mediciones_electricas_api.Dtos.Orden;
using mediciones_electricas_api.Dtos.Productos;
using mediciones_electricas_api.Dtos.Prueba;
using mediciones_electricas_api.Dtos.Puestos;
using mediciones_electricas_api.Dtos.TestPlan;
using mediciones_electricas_api.Dtos.TipoPrueba;
using mediciones_electricas_api.Models;

namespace mediciones_electricas_api
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Ejemplo de sintaxis
            //CreateMap< Fuente, Destino>();


            //Empleado
          
            CreateMap<Empleado, DtoEmpleadoNuevoEditar>();
            CreateMap<Empleado, DtoEmpleado>();
            CreateMap<DtoEmpleadoNuevoEditar, Empleado>();


            //Equipos
            CreateMap<Equipo, DtoEquipo>();
            CreateMap<Equipo, DtoEquipoNuevoEditar>();
            CreateMap<DtoEquipoNuevoEditar, Equipo>();
            CreateMap<DtoEquipo, Equipo>();

            //Linea de produccion
            CreateMap<LineaProduccion, DtoLineaProduccion>();
            CreateMap<LineaProduccion, DtoLineaProduccionNuevoEditar>();
            CreateMap<DtoLineaProduccionNuevoEditar, LineaProduccion>();
            CreateMap<DtoLineaProduccion, LineaProduccion>();

            //Login
            CreateMap<Login, DtoLoginNuevoEditar>();
            CreateMap<Login, DtoLoginIniciarSesion>();

            //Modelos
            CreateMap<Modelo, DtoModeloNuevoEditar>();
            CreateMap<DtoModeloNuevoEditar, Modelo>();
            CreateMap<Modelo, DtoModelo>().ReverseMap();

            //Productos
            CreateMap<Producto, DtoProducto>();
            CreateMap<DtoProductoNuevoEditar, Producto>();
            CreateMap<DtoProducto, Producto>();
            CreateMap<Producto, DtoProductoNuevoEditar>();

            //Puestos
            CreateMap<Puesto, DtoPuesto>();
            CreateMap<Puesto, DtoPuestoNuevoEditar>();
            CreateMap<DtoPuesto, Puesto>();
            CreateMap<DtoPuestoNuevoEditar, Puesto>();

            //TestPlan
            CreateMap<TestPlan, DtoTestPlan>();
            CreateMap<TestPlan, DtoTestPlanNuevoEditar>();
            CreateMap<DtoTestPlan, TestPlan>();
            CreateMap<DtoTestPlanNuevoEditar, TestPlan>();

            //TipoPrueba

            CreateMap<TipoPrueba, DtoTipoPrueba>().ReverseMap();
            CreateMap<TipoPrueba, DtoTipoPruebaNuevoEditar>().ReverseMap();

            //Prueba

            CreateMap<Prueba, DtoPrueba>().ReverseMap();
            CreateMap<Prueba, DtoPruebaNuevoEditar>().ReverseMap();
            CreateMap<Prueba, DtoGraficaResultadosPorTipoDePrueba>().ReverseMap();

            //Orden

            CreateMap<Orden, DtoOrden>().ReverseMap();
            CreateMap<Orden, DtoOrdenNuevoEditar>().ReverseMap();
            CreateMap<Orden, DtoGraficaOrdenCantidadPorMes>().ReverseMap();
        }

    }
}
