# Write your MySQL query statement below
SELECT DISTINCT num1.Num
AS ConsecutiveNums
FROM Logs num1, Logs num2, Logs num3
WHERE num1.Id = num2.Id - 1
AND num1.Num = num2.Num
AND num2.Id = num3.Id - 1
And num2.Num = num3.Num
