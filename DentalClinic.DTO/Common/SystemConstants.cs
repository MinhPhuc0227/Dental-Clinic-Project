using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.BLL.Common
{
    public static class SystemConstants
    {
        // ===== CẤU HÌNH CHO LỊCH HẸN =====
        // 1. Độ dài mặc định 1 ca khám -> từ đó chặn bệnh nhân đặt trùng khung giờ với nhau
        public const int DefaultSlotDurationMinutes = 30;
        // 2. Số ngày đặt trước tối đa
        public const int MaxAdvanceBookingDays = 30;
        // 3. Số phút cho phép check-in sớm
        public const int AllowedEarlyCheckInMinutes = 30;
        // 4. Số phút cho phép check-in muộn
        public const int AllowedLateCheckInMinutes = 30;


        // ===== CẤU HÌNH CHO PHÉP TIẾP NHẬN =====
        // Ngưỡng bệnh nhân tối đa cho phép của một bác sĩ trong ngày trước khi cảnh báo quá tải
        public const int MaxDailyVisitsPerDoctor = 20;
       

        // ===== NGƯỠNG CẢNH BÁO SẮP HẾT HÀNG =====
        public const int LowStockThreshold = 10;


        // ===== GIỜ LÀM VIỆC CỦA PHÒNG KHÁM =====
        // Buổi sáng: giả sử 8:00 - 11:30
        public static readonly TimeSpan MorningStartTime = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan MorningEndTime = new TimeSpan(11, 30, 0);
        // Buổi chiều: giả sử 13:30 - 17:00
        public static readonly TimeSpan AfternoonStartTime = new TimeSpan(13, 30, 0);
        public static readonly TimeSpan AfternoonEndTime = new TimeSpan(17, 0, 0);
    }
}
