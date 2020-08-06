insert into Administrators (ID, Name, Login, Password) values (1, 'John', 'john123', 'john678')
go

insert into Administrators (ID, Name, Login, Password) values (2, 'William', 'william_kop', '9398488')
go

insert into Administrators (ID, Name, Login, Password) values (3, 'Michael', 'michael_lkt', '32442')
go




insert into NumberFlight (ID, NumberFlight) values (1, 'SU1107')

insert into NumberFlight (ID, NumberFlight) values (2, 'PR1109')

insert into NumberFlight (ID, NumberFlight) values (3, 'TU1108')

insert into NumberFlight (ID, NumberFlight) values (4, 'AR1134')

insert into NumberFlight (ID, NumberFlight) values (5, 'QW1178')

insert into NumberFlight (ID, NumberFlight) values (6, 'PO1190')

insert into NumberFlight (ID, NumberFlight) values (7, 'WE1201')

insert into NumberFlight (ID, NumberFlight) values (8, 'PX1221')

insert into NumberFlight (ID, NumberFlight) values (9, 'MN1229')

insert into NumberFlight (ID, NumberFlight) values (10, 'NB1249')




insert into Passengers (ID, Num_ID, Name, Surname, Age, Phone) values (1,1, 'David', 'Smith', 32, 89236669301)
go

insert into Passengers (ID, Num_ID, Name, Surname, Age, Phone) values (2,1, 'Connor', 'Walker', 34, 89306669001)
go

insert into Passengers (ID, Num_ID, Name, Surname, Age, Phone) values (3,1,'Ryan', 'Brown', 25, 89156939301)
go

insert into Passengers (ID, Num_ID, Name, Surname, Age, Phone) values (4,1, 'Tom', 'Redison', 30, 89108909371)
go

insert into Passengers (ID, Num_ID, Name, Surname, Age, Phone) values (5,1, 'Ayaz', 'Perlov', 30, 89052347801)
go

insert into Passengers (ID, Num_ID, Name, Surname, Age, Phone) values (6,1, 'Vanya', 'Perlov', 25, 89224567834)
go

insert into Passengers (ID, Num_ID, Name, Surname, Age, Phone) values (7,1, 'William', 'Will', 27, 89224567834)
go




insert into Airplanes (ID, Airplanes_Name, Airplanes.Pilot,  Serial_Number, Quantity_Seats, Flight_Height) values (1,'Airbus A330', 'Vasiliy', 15630, 600, 10500)
go

insert into Airplanes (ID, Airplanes_Name, Airplanes.Pilot, Serial_Number, Quantity_Seats, Flight_Height) values (2,'Boeing-737', 'Ilya',  14366, 900, 11500)
go

insert into Airplanes (ID, Airplanes_Name, Airplanes.Pilot, Serial_Number, Quantity_Seats, Flight_Height) values (3,'Boeing-757', 'Yuriy',  12637, 500, 11000)
go

insert into Airplanes (ID, Airplanes_Name, Airplanes.Pilot, Serial_Number, Quantity_Seats, Flight_Height) values (4,'Туполев Ту-204', 'Ivan',  14555, 700, 12000)
go

insert into Airplanes (ID, Airplanes_Name, Airplanes.Pilot, Serial_Number, Quantity_Seats, Flight_Height) values (5,'Boeing-777', 'Valeriy',  14777, 777, 10300)
go




insert into Day_Plan (ID, Administrators_ID,  Date, Required_uantity_of_flights, Minimal_uantity_of_flights, Airplane,DepartureDate, ArrivialDate, FlightNumber) values (1, 1, '2020-05-16', 30, 10, 'Airbus A330' ,'14:00:00', '17:00:00', 'SU1107')
go


insert into Day_Plan (ID, Administrators_ID, Date, Required_uantity_of_flights, Minimal_uantity_of_flights, Airplane,DepartureDate, ArrivialDate, FlightNumber) values (2, 1, '2020-05-16',50,20, 'Boeing-757' ,'10:30:00', '12:30:00', 'TU1108')
go


insert into Day_Plan (ID, Administrators_ID, Date, Required_uantity_of_flights, Minimal_uantity_of_flights, Airplane,DepartureDate, ArrivialDate, FlightNumber) values (3, 1, '2020-05-14', 40,20 )
go




insert into Runways (ID, Nimber, Lenght) values (1, 1, 2000)
go


insert into Runways (ID, Nimber, Lenght) values (2, 2, 5000)
go


insert into Runways (ID, Nimber, Lenght) values (3, 3, 10000)
go




insert into Weather_Report (ID, Date, Forecast, Verdict) values (1, '2020-05-16', 'cloudy, clear at times', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (2, '2020-05-13', 'thunderstorm, gusty wind', 0)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (3, '2020-05-14', 'cloudy, windless', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (4, '2020-05-15', 'cloudy, windless', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (5, '2020-05-17', 'cloudy, windless', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (6, '2020-05-18', 'cloudy, windless', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (7, '2020-05-19', 'cloudy, windless', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (8, '2020-05-20', 'cloudy, windless', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (9, '2020-05-21', 'cloudy, windless', 1)
go

insert into Weather_Report (ID, Date, Forecast, Verdict) values (10, '2020-05-', 'cloudy, windless', 1)
go




insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID,  Airplanes_ID) values (1,'2020-05-16', 1, 1, 1, 1)
go

insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID, Airplanes_ID) values (2,'2020-05-14', 2, 2, 3, 2)
go

insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID, Airplanes_ID) values (3,'2020-05-16', 2, 1, 1, 3)
go

insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID, Airplanes_ID) values (4,'2020-05-17', 2, 1, 5, 1)
go

insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID, Airplanes_ID) values (5,'2020-05-18', 2, 1, 6, 4)
go

insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID, Airplanes_ID) values (6,'2020-05-19', 2, 1, 7, 2)
go

insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID, Airplanes_ID) values (7,'2020-05-20', 2, 1, 8, 5)
go

insert into PlanApplicationFlight(ID, Date, Runways_ID, NumberFlight_ID, Wea_ID, Airplanes_ID) values (8,'2020-05-16', 1, 1, 1, 1)
go


--
insert into Day_Plan(ID,Administrators_ID,Date,Airplane,ArrivialDate, DepartureDate,Minimal_uantity_of_flights, FlightNumber ) 
values (1, 1,'2020-05-16', 1, '', '', 30, 10, 'SU1107')
go

insert into Day_Plan(ID,Administrators_ID,Date,Airplane,ArrivialDate, DepartureDate,Minimal_uantity_of_flights, FlightNumber ) 
values (2, 1,'2020-05-16', 2, '', '', 30, 10, 'SU1107')
go
--

insert into Day_Plan(ID,Administrators_ID,Date,Airplane,ArrivialDate, DepartureDate,Minimal_uantity_of_flights, Required_uantity_of_flights, FlightNumber ) 
values (3, 1,'2020-05-15', 'Boeing-757', '09:00:00', '14:00:00', 50, 10, 'PO1190')
go

insert into Day_Plan(ID,Administrators_ID,Date,Airplane,ArrivialDate, DepartureDate,Minimal_uantity_of_flights, Required_uantity_of_flights, FlightNumber ) 
values (4, 1,'2020-05-15', 'Туполев Ту-204', '15:00:00', '21:00:00', 50, 10, 'PO1190')
go

insert into Day_Plan(ID,Administrators_ID,Date,Airplane,ArrivialDate, DepartureDate,Minimal_uantity_of_flights, Required_uantity_of_flights, FlightNumber ) 
values (5, 1,'2020-05-17','Boeing-777', '21:00:00', '23:00:00', 20, 10, 'PO1190')
go



insert into Journal (ID, Date, Adm_ID, Event, Remark) values (1,'2020-05-14', 1, 'no unforeseen events', 'Today everything is according to plan')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (2,'2020-05-14', 2, 'Airbus A330 was late due to meteorological conditions', 'Plan not fulfilled')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (3,'2020-05-16', 1, 'no unforeseen events', 'Today everything is according to plan, with a few comments')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (4,'2020-05-17', 1, 'no unforeseen events', 'Today everything is according to plan, with a few comments')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (5,'2020-05-18', 1, 'no unforeseen events', 'Today everything is according to plan')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (6,'2020-05-19', 1, 'no unforeseen events', 'Today everything is according to plan, with a few comments')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (7,'2020-05-20', 1, 'no unforeseen events', 'Today everything is according to plan')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (8,'2020-05-21', 1, 'no unforeseen events', 'Today everything is according to plan, with a few comments')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (9,'2020-05-22', 1, 'no unforeseen events', 'Today everything is according to plan, with a few comments')
go

insert into Journal (ID, Date, Adm_ID, Event, Remark) values (10,'2020-05-23', 1, 'no unforeseen events', 'Today everything is according to plan')
go


