using ClinicManagement.Application.Contracts.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Project.Controllers
{



    /// <summary>
    /// کنترلر دکتر
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorApplication _doctorApplication;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorApplication doctorApplication, ILogger<DoctorController> logger)
        {
            _doctorApplication = doctorApplication;
            _logger = logger;
        }


        /// <summary>
        /// ایجاد دکتر جدید.
        /// </summary>
        /// <param name="command">مشخصات مورد نیاز برای ایجاد دکتر.
        /// <list type="bullet">
        /// <item><description><c>FullName</c>: نام و نام خانوادگی دکتر.</description></item>
        /// <item><description><c>Specialty</c>: تخصص دکتر</description></item>
        /// <item><description><c>City</c>:شهر سکونت دکتر</description></item>
        /// <item><description><c>MedicalLicenseNumber</c>:  شماره پروانه پزشکی دکتر.</description></item>
        /// <item><description><c>ClinicNumber</c>: شماره مطب</description></item>
        /// <item><description><c>Biography</c>: معرفی دکتر و بیوگرافی آن</description></item>
        /// <item><description><c>Photo</c>: عکس</description></item>
        /// </list>
        /// </param>
        /// <returns>در صورت موفقیت، وضعیت 201  را با جزئیات پزشک ایجاد شده برمی‌گرداند.
        /// اگر داده های ورودی نامعتبر باشد، وضعیت  400 را با یک پیام خطا برمی گرداند.
        /// یا اگر پزشکی با همین نام از قبل وجود داشته باشد.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateDoctor command)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("ModelState is invalid: {Errors}", string.Join(", ", errors));
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _doctorApplication.Create(command);
                if (result.IsSuccedded)
                {
                    return CreatedAtAction(nameof(GetDetails), new { id = result.Id }, command);
                }

                _logger.LogWarning("Create failed: {Message}", result.Message);
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }

        }

        /// <summary>
        /// ویرایش مشخصات دکتر
        /// </summary>
        /// <param name="command">موارد زیر را شامل می شود:
        /// <list type="bullet">
        /// <item><description><c>Id</c>: شناسه دکتر</description></item>
        /// <item><description><c>FullName</c>: نام و نام خانوادگی دکتر</description></item>
        /// <item><description><c>Specialty</c>:تخصص دکتر.</description></item>
        /// <item><description><c>City</c>:شهر محل سکونت دکتر</description></item>
        /// <item><description><c>MedicalLicenseNumber</c>: شماره پروانه پزشکی.</description></item>
        /// <item><description><c>ClinicNumber</c>: شماره مطب</description></item>
        /// <item><description><c>Biography</c>: بیوگرافی دکتر.</description></item>
        /// <item><description><c>Photo</c>: عکس دکتر.</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// در صورت موفقیت آمیز بودن ویرایش، وضعیت 204 بدون محتوا را برمی گرداند.
        /// اگر داده‌های ورودی نامعتبر باشد یا اگر پزشک وجود نداشته باشد، وضعیت  400 را برمی‌گرداند.
        /// گر پزشک با شناسه مشخص شده وجود نداشته باشد، وضعیت 404 یافت نشد را برمی‌گرداند.
        /// </returns>
        /// <remarks>
        /// Example request:
        /// 
        /// PUT /api/doctor/edit
        /// {
        ///     "Id": 1,
        ///     "FullName":  حسام صادقی",
        ///     "Specialty": "قلب و عروق",
        ///     "City": "تهران",
        ///     "MedicalLicenseNumber": "77766",
        ///     "ClinicNumber": "021_4455666",
        ///     "Biography": "متخصص قلب و عروق با بیش از 10 سال سابقه کار.",
        ///     "Photo": "h.sadeghi.jpg"
        /// }
        /// </remarks>
        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] EditDoctor commamd)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _doctorApplication.Edit(commamd);
            if (result.IsSuccedded)
                return NoContent();

            return BadRequest(result.Message);
        }







        /// <summary>
        /// نمایش جزییات یک دکتر بر اساس شناسه آن
        /// </summary>
        /// <param name="id">شناسه پزشک مورد نظر برای بازیابی.</param>
        /// <returns>اگر پزشک پیدا شود جزییات مورد نظز برمی گرداند در غیر این صورت وضعیت 404</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {

            var doctor = await _doctorApplication.GetDetails(id);
            if (doctor == null)
                return NotFound();


            return Ok(doctor);

        }


        /// <summary>
        /// لیستی از تمام پزشکان دریافت می کند.
        /// </summary>
        /// <returns>> فهرستی از پزشکان را برمی گرداند.</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorApplication.GetDoctors();
            return Ok(doctors);
        }

        /// <summary>
        /// بر اساس معیارهای جستجو شده، پزشکان را جستجو می کند.
        /// </summary>
        /// <param name="searchModel">معیارهای جستجو برای یافتن پزشکان</param>
        /// <returns>فهرستی از پزشکان را برمی‌گرداند که با معیارهای جستجو مطابقت دارند.</returns>
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] DoctorSearchModel searchModel)
        {
            var doctors = await _doctorApplication.Search(searchModel);
            return Ok(doctors);
        }

    }
}
