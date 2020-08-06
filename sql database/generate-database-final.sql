/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     28.05.2020 15:29:08                          */
/*==============================================================*/


/*==============================================================*/
/* Table: Administrators                                        */
/*==============================================================*/
create table Administrators (
   ID                   int                  not null,
   Name                 varchar(20)          null,
   Login                varchar(20)          null,
   Password             varchar(20)          null
)
go

alter table Administrators
   add constraint PK_ADMINISTRATORS primary key (ID)
go

/*==============================================================*/
/* Table: Airplanes                                             */
/*==============================================================*/
create table Airplanes (
   ID                   int                  not null,
   Airplanes_Name       varchar(20)          null,
   Pilot                varchar(20)          null,
   Serial_Number        bigint               null,
   Quantity_Seats       int                  null,
   Flight_Height        bigint               null
)
go

alter table Airplanes
   add constraint PK_AIRPLANES primary key (ID)
go

/*==============================================================*/
/* Table: Day_Plan                                              */
/*==============================================================*/
create table Day_Plan (
   ID                   int                  not null,
   Administrators_ID    int                  null,
   Date                 date             null,
   Required_uantity_of_flights int                  null,
   Minimal_uantity_of_flights int                  null,
   Airplane					varchar(20)            null,
   DepartureDate            time               null,
   ArrivialDate             time              null,
   FlightNumber             varchar(6)             null,
)
go

alter table Day_Plan
   add constraint PK_DAY_PLAN primary key (ID)
go

/*==============================================================*/
/* Table: Journal                                               */
/*==============================================================*/
create table Journal (
   ID                   int                  not null,
   Date                 date             null,
   Adm_ID               int                  null,
   Event                varchar(50)          null,
   Remark               varchar(50)          null
)
go

alter table Journal
   add constraint PK_JOURNAL primary key (ID)
go

/*==============================================================*/
/* Table: NumberFlight                                          */
/*==============================================================*/
create table NumberFlight (
   ID                   int                  not null,
   NumberFlight         varchar(6)           null
)
go

alter table NumberFlight
   add constraint PK_NUMBERFLIGHT primary key (ID)
go

/*==============================================================*/
/* Table: Passengers                                            */
/*==============================================================*/
create table Passengers (
   ID                   int                  not null,
   Num_ID               int                  null,
   Name                 varchar(50)          null,
   Surname              varchar(50)          null,
   Age                  int                  null,
   Phone                varchar(20)          null
)
go

alter table Passengers
   add constraint PK_PASSENGERS primary key (ID)
go

/*==============================================================*/
/* Table: PlanApplicationFlight                                 */
/*==============================================================*/
create table PlanApplicationFlight (
   ID                   int                  not null,
   Date                 date             null,
   Runways_ID           int                  null,
   NumberFlight_ID      int                  null,
   Wea_ID               int                  null,
   Airplanes_ID         int                  null
)
go

alter table PlanApplicationFlight
   add constraint PK_PLANAPPLICATIONFLIGHT primary key (ID)
go

/*==============================================================*/
/* Table: Runways                                               */
/*==============================================================*/
create table Runways (
   ID                   int                  not null,
   Nimber               int                  null,
   Lenght               bigint               null,
   Busy                 bit                  null
)
go

alter table Runways
   add constraint PK_RUNWAYS primary key (ID)
go

/*==============================================================*/
/* Table: Weather_Report                                        */
/*==============================================================*/
create table Weather_Report (
   ID                   int                  not null,
   Date                 date             null,
   Forecast             varchar(50)          null,
   Verdict              bit                  null
)
go

alter table Weather_Report
   add constraint PK_WEATHER_REPORT primary key (ID)
go

alter table Day_Plan
   add constraint FK_DAY_PLAN_SELECT_FI_ADMINIST foreign key (Administrators_ID)
      references Administrators (ID)
go

alter table Journal
   add constraint FK_JOURNAL_TRUTH_OF__ADMINIST foreign key (Adm_ID)
      references Administrators (ID)
go

alter table Passengers
   add constraint FK_PASSENGE_PASSENGER_NUMBERFL foreign key (Num_ID)
      references NumberFlight (ID)
go

alter table PlanApplicationFlight
   add constraint FK_PLANAPPL_INCLUDE_A_AIRPLANE foreign key (Airplanes_ID)
      references Airplanes (ID)
go

alter table PlanApplicationFlight
   add constraint FK_PLANAPPL_INCLUDE_R_RUNWAYS foreign key (Runways_ID)
      references Runways (ID)
go

alter table PlanApplicationFlight
   add constraint FK_PLANAPPL_INCLUDE_W_WEATHER_ foreign key (Wea_ID)
      references Weather_Report (ID)
go

alter table PlanApplicationFlight
   add constraint "FK_PLANAPPL_WRITE FLI_NUMBERFL" foreign key (NumberFlight_ID)
      references NumberFlight (ID)
go

