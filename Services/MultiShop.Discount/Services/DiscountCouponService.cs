using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly DapperContext _context;

        public DiscountCouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCoupon)
        {
            var query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values(@Code,@Rate,@IsActive,@ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createCoupon.Code);
            parameters.Add("@Rate", createCoupon.Rate);
            parameters.Add("@IsActive", createCoupon.IsActive);
            parameters.Add("@ValidDate", createCoupon.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            var query = "Delete From Coupons Where CouponID=@CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            var query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<ResultDiscountCouponDto>(query);

                return value.ToList();
            }

        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponDtoAsync(int id)
        {
            var query = "Select * From Coupons where CouponID=@CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCoupon)
        {
            var query = "Update Coupons Set Code=@Code,Rate=@Rate,IsActive=@IsActive,ValidDate=@ValidDate Where CouponID=@CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", updateCoupon.CouponID);
            parameters.Add("@Code", updateCoupon.Code);
            parameters.Add("@Rate", updateCoupon.Rate);
            parameters.Add("@IsActive", updateCoupon.IsActive);
            parameters.Add("@ValidDate", updateCoupon.ValidDate);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
