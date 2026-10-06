> **English version below.**

# Dental Clinic Management System

## Giới thiệu

Hệ thống quản lý phòng khám nha khoa dạng desktop được xây dựng nhằm tập
trung hóa và hỗ trợ quản lý các hoạt động của phòng khám, bao gồm đặt lịch
hẹn, hồ sơ bệnh nhân, điều trị, tồn kho thuốc, thanh toán và báo cáo.

## Bài toán

Các hoạt động tại phòng khám nha khoa có thể trở nên khó quản lý khi lịch hẹn,
hồ sơ bệnh nhân, theo dõi điều trị, quản lý thuốc và thanh toán được xử lý qua
các quy trình riêng biệt.

Dự án được xây dựng nhằm tập trung hóa các quy trình này, cải thiện khả năng
kiểm soát hoạt động, đảm bảo tính nhất quán của dữ liệu và hỗ trợ quản lý
thông tin hiệu quả hơn.

## Vai trò

**Personal Project**

## Phân tích yêu cầu

Hệ thống được thiết kế cho ba nhóm người dùng chính:

- **Admin**
- **Receptionist**
- **Dentist**

Dự án tập trung phân tích quy trình hoạt động của phòng khám và xác định
yêu cầu, trách nhiệm của từng nhóm người dùng.

## Phân tích & Thiết kế hệ thống

### Mô hình hóa nghiệp vụ & hệ thống

- Use Case Diagram
- Activity Diagram
- Sequence Diagram
- Entity Relationship Diagram (ERD)

### Kiến trúc hệ thống

Hệ thống được tổ chức theo kiến trúc ba lớp:

- **UI** - User Interface
- **BLL** - Business Logic Layer
- **DAL** - Data Access Layer

Hệ thống cũng áp dụng DTO để truyền dữ liệu và Dependency Injection (DI)
nhằm giảm sự phụ thuộc giữa các thành phần.

## Chức năng chính

- Quản lý và đặt lịch hẹn
- Quản lý hồ sơ bệnh nhân
- Theo dõi điều trị và tiến độ điều trị
- Quản lý tồn kho thuốc
- Quản lý kê đơn thuốc
- Quản lý thanh toán và hóa đơn
- Báo cáo thống kê

## Quy tắc nghiệp vụ

Hệ thống hỗ trợ một số quy tắc nghiệp vụ như:

- Ngăn ngừa xung đột lịch hẹn
- Kiểm tra tồn kho thuốc trước khi kê đơn
- Theo dõi tiến độ điều trị
- Duy trì tính nhất quán của dữ liệu
- Hỗ trợ báo cáo doanh thu và tồn kho

## Công nghệ sử dụng

- C#
- .NET
- Windows Forms
- Entity Framework Core
- LINQ
- Microsoft SQL Server

## Công cụ

- Draw.io
- dbdiagram.io
- Visual Studio

## Tài liệu dự án

- Use Case Diagram
- Activity Diagram
- Sequence Diagram
- ERD
- System Architecture
- User Interface

## Kết quả

Hoàn thiện một hệ thống quản lý desktop hỗ trợ các quy trình cốt lõi của
phòng khám nha khoa, bao gồm quản lý lịch hẹn, bệnh nhân, điều trị, thuốc,
thanh toán và báo cáo.

---

# English Version

## Overview

A centralized desktop management system designed to streamline dental clinic
operations, covering appointment scheduling, patient records, treatment,
medication inventory, billing, and reporting.

## Business Problem

Dental clinic operations can become difficult to manage when appointment
scheduling, patient records, treatment tracking, medication, and billing are
handled across disconnected processes.

The project was developed to centralize these workflows, improve process
control, maintain data consistency, and support more effective information
management.

## Project Role

**Personal Project**

## Requirements Analysis

The system was designed for three main user groups:

- **Admin**
- **Receptionist**
- **Dentist**

The project focused on analyzing clinic workflows and identifying the
requirements and responsibilities of each user group.

## System Analysis & Design

### Business & System Modeling

- Use Case Diagram
- Activity Diagram
- Sequence Diagram
- Entity Relationship Diagram (ERD)

### Architecture

The system follows a three-layer architecture:

- **UI** - User Interface
- **BLL** - Business Logic Layer
- **DAL** - Data Access Layer

The system also applies DTO for data transfer and Dependency Injection (DI)
to reduce coupling between components.

## Key Features

- Appointment scheduling and management
- Patient record management
- Treatment and treatment progress tracking
- Medication inventory management
- Prescription management
- Billing and invoice management
- Statistical reporting

## Business Rules

The system supports several operational rules, including:

- Preventing appointment conflicts
- Checking medication inventory before prescription
- Tracking treatment progress
- Maintaining data consistency
- Supporting revenue and inventory reporting

## Technologies

- C#
- .NET
- Windows Forms
- Entity Framework Core
- LINQ
- Microsoft SQL Server

## Tools

- Draw.io
- dbdiagram.io
- Visual Studio

## Project Artifacts

- Use Case Diagram
- Activity Diagram
- Sequence Diagram
- ERD
- System Architecture
- User Interface

## Outcome

Completed a functional desktop management system supporting core dental
clinic workflows, including appointment scheduling, patient management,
treatment tracking, medication inventory, billing, and reporting.
