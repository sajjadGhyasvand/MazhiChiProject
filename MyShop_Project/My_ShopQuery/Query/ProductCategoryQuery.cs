
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.Product;
using My_ShopQuery.Contract.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
           

            return _context.ProductCategories
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    PictureTitle = x.PictureTitle,
                    Picture = x.Picture,
                    Description = x.Description,
                    Keyword = x.Keyword,
                    Name = x.Name,
                    PictureAlt = x.PictureAlt,
                    LanguageId = x.LanguageId,
                    Slug = x.Slug,
                    Icon = x.Icon,
                    Products = x.Products
                        .OrderBy(p => p.Id)
                        .Take(4)
                        .Select(p => new ProductQueryModel
                        {
                            Id = p.Id,
                            Category = p.Category.Name,
                            Name = p.Name,
                            Picture = p.Picture,
                            PictureAlt = p.PictureAlt,
                            PictureTitle = p.PictureTitle,
                            ShortDescription = p.ShortDescription,
                            Slug = p.Slug,
                            LanguageId = p.LanguageId
                        }).ToList()
                })
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();
        }


        public List<ProductCategoryQueryModel> GetAllCategory()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
           
            var categories = _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(
                x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products),
                    Slug = x.Slug,
                    LanguageId = x.LanguageId
                }).AsNoTracking();

            return categories.ToList();
        }

        public ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var category = _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keyword = x.Keyword,
                Slug = x.Slug,
                Products = MapProducts(x.Products),

            }).FirstOrDefault(x => x.Slug == slug);
            if (category != null)
            {
                foreach (var product in category.Products)
                {
                    product.CategorySlug = category.Slug;
                }
            }
            return category;
        }

        public static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            var product= products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                LanguageId = x.LanguageId

            });
            return product.ToList();
        }
    }
}