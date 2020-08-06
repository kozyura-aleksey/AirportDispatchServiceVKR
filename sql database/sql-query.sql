SELECT Airplanes_Name, Passengers.Name, Passengers.Surname FROM Preparatory_shredule 
INNER JOIN Runways ON Preparatory_shredule.Run_ID = Runways.ID 
INNER JOIN Airplanes ON Preparatory_shredule.Air_ID = Airplanes.ID
INNER JOIN Passengers ON Preparatory_shredule.Pas_ID = Passengers.ID
INNER JOIN Day_Plan ON Preparatory_shredule.Day_ID = Day_Plan.ID
INNER JOIN Weather_Report ON Preparatory_shredule.Wea_ID = Weather_Report.ID
INNER JOIN Administrators ON Preparatory_shredule.Adm_ID = Administrators.ID
WHERE Weather_Report.Verdict = 1 AND (Weather_Report.Date = ?)


--Итоговое расписание
SELECT Preparatory_shredule.ID, Run_ID, Date, Air_ID, Pas_ID, Day_ID, Wea_ID, Adm_ID FROM Preparatory_shredule JOIN Weather_Report 
ON Preparatory_shredule.Wea_ID = Weather_Report.ID 
WHERE Weather_Report.Verdict = 1 

--Итогове расписание с JOIN
SELECT Runways.Nimber, Airplanes.Airplanes_Name, Airplanes.Serial_Number, Airplanes.Quantity_Seats, Passengers.ID, Passengers.Name, Passengers.Surname, Passengers.Age, Passengers.Phone FROM Preparatory_shredule 
JOIN Runways ON Preparatory_shredule.Run_ID = Runways.ID 
JOIN Airplanes ON Preparatory_shredule.Air_ID = Airplanes.ID
JOIN Passengers ON Preparatory_shredule.Pas_ID = Passengers.ID
JOIN Day_Plan ON Preparatory_shredule.Date = Day_Plan.Date
JOIN Weather_Report ON Preparatory_shredule.Date = Weather_Report.Date
WHERE (Weather_Report.Verdict = 1)

--Подсчет записей в таблице
SELECT COUNT(ID) FROM Preparatory_shredule

--Итоговый запрос на расписание
SELECT Runways.Nimber,Day_Plan.Required_uantity_of_flights, Airplanes.Airplanes_Name, Airplanes.Serial_Number, Airplanes.Quantity_Seats, Passengers.ID, Passengers.Name, Passengers.Surname, Passengers.Age, Passengers.Phone FROM Preparatory_shredule 
JOIN Runways ON Preparatory_shredule.Run_ID = Runways.ID 
JOIN Airplanes ON Preparatory_shredule.Air_ID = Airplanes.ID
JOIN Passengers ON Preparatory_shredule.Pas_ID = Passengers.ID
JOIN Day_Plan ON Preparatory_shredule.Day_ID = Day_Plan.ID
JOIN Weather_Report ON Preparatory_shredule.Wea_ID = Weather_Report.ID
WHERE (Weather_Report.Verdict = 1)
GROUP BY Runways.Nimber, Day_Plan.Required_uantity_of_flights, Airplanes.Airplanes_Name, Airplanes.Serial_Number, Airplanes.Quantity_Seats, Passengers.ID, Passengers.Name, Passengers.Surname, Passengers.Age, Passengers.Phone
HAVING ((COUNT(Preparatory_shredule.ID) < Day_Plan.Required_uantity_of_flights))


--Запрос на сохранение расписания(изменение взлетной полосы для какого-то самолета)
UPDATE Preparatory_shredule SET Run_ID = null WHERE ID = 4


--Запрос на заявки по полетам
SELECT PlanApplicationFlight.Date, Runways.Nimber, NumberFlight.NumberFlight, Weather_Report.Forecast, Weather_Report.Verdict, Airplanes.Airplanes_Name,  Airplanes.Pilot, Airplanes.Serial_Number FROM PlanApplicationFlight  
JOIN Runways ON PlanApplicationFlight.ID = Runways.ID
JOIN NumberFlight ON NumberFlight.ID = PlanApplicationFlight.ID
JOIN Weather_Report ON PlanApplicationFlight.Wea_Id = Weather_Report.ID
JOIN Airplanes ON Airplanes.ID = PlanApplicationFlight.ID
WHERE (PlanApplicationFlight.Date = '2020-05-16')

--Запрос на суточный план дня
SELECT Day_Plan.Date, PlanApplicationFlight_ID, Weather_Report.Forecast, Weather_Report.Verdict, Administrators.Name, Required_uantity_of_flights, Minimal_uantity_of_flights FROM Day_Plan
JOIN Weather_Report ON Weather_Report.Date = Day_Plan.Date
JOIN Administrators ON Administrators.ID = Day_Plan.ID

--Количество пассажиров на определенном рейсе
SELECT COUNT(*) AS Passengers FROM Passengers
WHERE Passengers.Num_ID = 1;

--Вывод пассажиров с рейсами
SELECT Passengers.ID, NumberFlight, Name, Surname, Age, Phone FROM Passengers 
JOIN NumberFlight ON Passengers.Num_ID = NumberFlight.ID


SELECT PlanApplicationFlight.Date, Runways.Nimber, NumberFlight.NumberFlight, Weather_Report.Forecast, Weather_Report.Verdict, Airplanes.Airplanes_Name,  Airplanes.Pilot, Airplanes.Serial_Number FROM PlanApplicationFlight 
JOIN Runways ON PlanApplicationFlight.Runways_ID = Runways.ID 
JOIN NumberFlight ON PlanApplicationFlight.NumberFlight_ID = NumberFlight.ID 
JOIN Weather_Report ON PlanApplicationFlight.Wea_Id = Weather_Report.ID 
JOIN Airplanes ON PlanApplicationFlight.Airplanes_ID = Airplanes.ID