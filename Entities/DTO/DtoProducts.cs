using Core.Abstract;

namespace Entities.DTO
{
    public class DtoProducts: IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainImage { get; set; }
        public decimal Price { get; set; }
    }
}
