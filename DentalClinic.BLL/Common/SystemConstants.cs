using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.BLL.Common
{
    public static class SystemConstants
    {
        // LỊCH HẸN 
        // Độ dài mặc định 1 ca khám
        public const int DefaultSlotDurationMinutes = 30;
        // Số ngày đặt trước tối đa
        public const int MaxAdvanceBookingDays = 30;

        // GIỜ LÀM VIỆC CỦA PHÒNG KHÁM
        public static readonly TimeSpan MorningStartTime = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan MorningEndTime = new TimeSpan(11, 30, 0);
        public static readonly TimeSpan AfternoonStartTime = new TimeSpan(13, 30, 0);
        public static readonly TimeSpan AfternoonEndTime = new TimeSpan(17, 0, 0);

        // KHO THUỐC
        // Ngưỡng cảnh báo sắp hết hàng
        //public const int LowStockThreshold = 10;
        // Ngưỡng cảnh báo cận date
        //public const int ExpiryWarningDays = 30;

        // KHÁC
        public const decimal VATRate = 0.08m; // VAT 8%
    }
}
