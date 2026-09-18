using Api_Plataforma_DB.Models;
using Api_Plataforma_DB.Models.Dtos;

namespace Api_Plataforma_DB.Interfaces
{
    public interface IProductoRepository
    {
        public Task<List<Producto>> GetProductos();
        public Task<string> CreateProducto(ProductoDto item);
        public Task<string> UpdateProducto(ProductoDto item, int id);
        public Task<string> DeleteProducto(int id);
    }
}