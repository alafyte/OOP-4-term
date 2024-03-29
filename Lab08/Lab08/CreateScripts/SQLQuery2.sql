use Planets;
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Венера', 6051, CAST(560.00 AS Decimal(8, 2)), 1, 0)
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Земля', 6371, CAST(5960.00 AS Decimal(8, 2)), 1, 1)
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Марс', 3389, CAST(1726.85 AS Decimal(8, 2)), 1, 0)
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Меркурий', 2439, CAST(730.00 AS Decimal(8, 2)), 1, 0)
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Нептун', 24622, CAST(7100.00 AS Decimal(8, 2)), 1, 0)
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Сатурн', 58232, CAST(11700.00 AS Decimal(8, 2)), 1, 0)
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Уран', 25362, CAST(4726.85 AS Decimal(8, 2)), 1, 0)
INSERT [dbo].[PLANETS] ([Name], [Radius], [Core_Temperature], [Have_Atmosphere], [Have_Life]) VALUES (N'Юпитер', 69911, CAST(19700.00 AS Decimal(8, 2)), 1, 0)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Ганимед', N'Юпитер', 2634, 1070000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Деймос', N'Марс', 25, 23460)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Деспина', N'Нептун', 75, 52000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Диона', N'Сатурн', 562, 238042)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Европа', N'Юпитер', 1560, 670900)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Ио', N'Юпитер', 1821, 421700)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Каллисто', N'Юпитер', 2410, 1882000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Крессида', N'Уран', 41, 36200)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Луна', N'Земля', 1737, 384467)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Наяда', N'Нептун', 33, 48227)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Нереида', N'Нептун', 170, 5513400)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Рея', N'Сатурн', 763, 527000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Розалинда', N'Уран', 36, 70000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Сетебос', N'Уран', 12, 38000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Титан', N'Сатурн', 5152, 1200000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Титания', N'Уран', 788, 436000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Тритон', N'Нептун', 1353, 330000)
INSERT [dbo].[SATELLITES] ([Name], [Planet_Name], [Radius], [Planetary_Distance]) VALUES (N'Фобос', N'Марс', 11, 6000)

