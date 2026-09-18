using Api_Plataforma_DB.Interfaces;
using Api_Plataforma_DB.Models;
using Api_Plataforma_DB.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Api_Plataforma_DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet("GetProductos")]
        public async Task<List<Producto>> Get()
        {
            return await _productoRepository.GetProductos();
        }

        [HttpPost("CreateProducto")]
        public async Task<string> Post([FromBody] ProductoDto item)
        {
            if (string.IsNullOrEmpty(item.Nombre))
            {
                return "El nombre del producto no puede estar vacio.";
            }

            if (item.Precio <= 0)
            {
                return "El precio del producto debe ser mayor a cero.";
            }

            if (item.Stock < 0)
            {
                return "El stock del producto no puede ser negativo.";
            }

            var respuesta = await _productoRepository.CreateProducto(item);
            return respuesta;
        }

        [HttpPut("UpdateProducto/{id}")]
        public async Task<string> Put(int id, [FromBody] ProductoDto item)
        {
            if (string.IsNullOrEmpty(item.Nombre))
            {
                return "El nombre del producto no puede estar vacio.";
            }
            if (item.Precio < 0)
            {
                return "El precio del producto debe ser mayor a cero.";
            }
            if (item.Stock < 0)
            {
                return "El stock del producto no puede ser negativo.";
            }
            var respuesta = await _productoRepository.UpdateProducto(item, id);
            if (respuesta == null)
            {
                return "No se encontro el producto con Id: {id}";
            }
            return "Producto actualizado correctamente.";
        }

        [HttpDelete("DeleteProducto/{id}")]
        public async Task<string> Delete(int id)
        {
            var respuesta = await _productoRepository.DeleteProducto(id);
            if (respuesta == null)
            {
                return "No se encontro el producto con Id: {id}";
            }

            return "Producto eliminado correctamente.";
        }
    }
}
