RESTORE DATABASE CalendarManagement
FROM DISK = 'C:\Users\cubes\source\repos\CalendarManagement2\CalendarManagement\Data\CalendarManagement.bak'
WITH MOVE 'CalendarManagement' TO 'C:\Users\cubes\source\repos\CalendarManagement2\CalendarManagement\Data\CalendarManagement.mdf',
     MOVE 'CalendarManagement_log' TO 'C:\Users\cubes\source\repos\CalendarManagement2\CalendarManagement\Data\CalendarManagement_log.ldf',
     REPLACE;