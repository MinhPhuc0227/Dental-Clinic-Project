using DentalClinic.DAL;
using DentalClinic.DTO;
using DentalClinic.DTO.Common;
using System;
using System.Collections.Generic;

namespace DentalClinic.BLL
{
    public class Dashboard_BLL
    {
        private readonly Dashboard_DAL _dal;

        public Dashboard_BLL()
            : this(
                new Dashboard_DAL(
                    new AppDbContext()))
        {
        }

        public Dashboard_BLL(
            Dashboard_DAL dal)
        {
            _dal = dal;
        }


        public Result<DashboardSummaryDto>
            GetSummary(
                DateTime fromDate,
                DateTime toDate)
        {
            try
            {
                return Result<DashboardSummaryDto>
                    .Success(
                        _dal.GetSummary(
                            fromDate,
                            toDate));
            }
            catch (Exception ex)
            {
                return Result<DashboardSummaryDto>
                    .Failure(
                        "Lỗi tải tổng quan: " +
                        ex.Message);
            }
        }


        public Result<List<DashboardDailyStatisticDto>>
            GetVisitStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            try
            {
                return Result<
                    List<DashboardDailyStatisticDto>>
                    .Success(
                        _dal.GetVisitStatistics(
                            fromDate,
                            toDate));
            }
            catch (Exception ex)
            {
                return Result<
                    List<DashboardDailyStatisticDto>>
                    .Failure(
                        "Lỗi tải thống kê lượt khám: " +
                        ex.Message);
            }
        }


        public Result<List<DashboardDailyStatisticDto>>
            GetRevenueStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            try
            {
                return Result<
                    List<DashboardDailyStatisticDto>>
                    .Success(
                        _dal.GetRevenueStatistics(
                            fromDate,
                            toDate));
            }
            catch (Exception ex)
            {
                return Result<
                    List<DashboardDailyStatisticDto>>
                    .Failure(
                        "Lỗi tải thống kê doanh thu: " +
                        ex.Message);
            }
        }


        public Result<List<DashboardVisitStatusDto>>
            GetVisitStatusStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            try
            {
                return Result<
                    List<DashboardVisitStatusDto>>
                    .Success(
                        _dal.GetVisitStatusStatistics(
                            fromDate,
                            toDate));
            }
            catch (Exception ex)
            {
                return Result<
                    List<DashboardVisitStatusDto>>
                    .Failure(
                        "Lỗi tải trạng thái lượt khám: " +
                        ex.Message);
            }
        }


        public Result<List<DashboardLowStockDto>>
            GetLowStockMedicines(
                int threshold = 10)
        {
            try
            {
                return Result<
                    List<DashboardLowStockDto>>
                    .Success(
                        _dal.GetLowStockMedicines(
                            threshold));
            }
            catch (Exception ex)
            {
                return Result<
                    List<DashboardLowStockDto>>
                    .Failure(
                        "Lỗi tải thuốc sắp hết: " +
                        ex.Message);
            }
        }


        public Result<List<DashboardRecentImportDto>>
            GetRecentImports(
                int count = 5)
        {
            try
            {
                return Result<
                    List<DashboardRecentImportDto>>
                    .Success(
                        _dal.GetRecentImports(
                            count));
            }
            catch (Exception ex)
            {
                return Result<
                    List<DashboardRecentImportDto>>
                    .Failure(
                        "Lỗi tải nhập kho: " +
                        ex.Message);
            }
        }


        public Result<List<DashboardDoctorStatisticDto>>
            GetDoctorStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            try
            {
                return Result<
                    List<DashboardDoctorStatisticDto>>
                    .Success(
                        _dal.GetDoctorStatistics(
                            fromDate,
                            toDate));
            }
            catch (Exception ex)
            {
                return Result<
                    List<DashboardDoctorStatisticDto>>
                    .Failure(
                        "Lỗi tải thống kê bác sĩ: " +
                        ex.Message);
            }
        }


        public Result<List<DashboardPatientStatisticDto>>
            GetPatientStatistics(
                DateTime fromDate,
                DateTime toDate)
        {
            try
            {
                return Result<
                    List<DashboardPatientStatisticDto>>
                    .Success(
                        _dal.GetPatientStatistics(
                            fromDate,
                            toDate));
            }
            catch (Exception ex)
            {
                return Result<
                    List<DashboardPatientStatisticDto>>
                    .Failure(
                        "Lỗi tải thống kê bệnh nhân: " +
                        ex.Message);
            }
        }
    }
}