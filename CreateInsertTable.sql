INSERT INTO public."Klient"(
	klient_fio, klient_nom_pasporta, klient_adres, klient_telefon, klient_mesto_rab, klient_plata)
	VALUES ('Петров А.А.', 110110, 'Ямьле д.2 кв.1', '89019010002', 'Работа1', 10000);
INSERT INTO public."Klient"(
	klient_fio, klient_nom_pasporta, klient_adres, klient_telefon, klient_mesto_rab, klient_plata)
	VALUES ('Сидоров А.Б.', 110111, 'Ямьле д.4 кв.10', '89019010004', 'Работа2', 15000);
INSERT INTO public."Klient"(
	klient_fio, klient_nom_pasporta, klient_adres, klient_telefon, klient_mesto_rab, klient_plata)
	VALUES ('Волков В.Г.', 110112, 'Мурадьяна д.10 кв.20', '89019010106', 'Работа3', 12000);
INSERT INTO public."Klient"(
	klient_fio, klient_nom_pasporta, klient_adres, klient_telefon, klient_mesto_rab, klient_plata)
	VALUES ('Андреева С.К.', 110115, 'Вахитова д.4 кв.50', '89019010207', 'Работа4', 50000);
INSERT INTO public."Klient"(
	klient_fio, klient_nom_pasporta, klient_adres, klient_telefon, klient_mesto_rab, klient_plata)
	VALUES ('Михайлова В.Д.', 110117, 'Юности д.1 кв.70', '89019010505', 'Работа5', 10000);
	
INSERT INTO public."Kredit"(kredit_tip, kredit_proc_stavka)
	VALUES ('Тип кредита 1', 5);
INSERT INTO public."Kredit"(kredit_tip, kredit_proc_stavka)
	VALUES ('Тип кредита 2', 6.5);
INSERT INTO public."Kredit"(kredit_tip, kredit_proc_stavka)
	VALUES ('Тип кредита 3', 7);
INSERT INTO public."Kredit"(kredit_tip, kredit_proc_stavka)
	VALUES ('Тип кредита 4', 7.5);
INSERT INTO public."Kredit"(kredit_tip, kredit_proc_stavka)
	VALUES ('Тип кредита 5', 8);	

INSERT INTO public."Dogovor"(dogovor_data_dogovora, dogovor_tip_dogovora, klient_id, kredit_id)
	VALUES ('2023-06-01', 'Тип договора 1', 1, 5);
INSERT INTO public."Dogovor"(dogovor_data_dogovora, dogovor_tip_dogovora, klient_id, kredit_id)
	VALUES ('2023-06-10', 'Тип договора 2', 2, 4);
INSERT INTO public."Dogovor"(dogovor_data_dogovora, dogovor_tip_dogovora, klient_id, kredit_id)
	VALUES ('2023-07-10', 'Тип договора 3', 3, 3);
INSERT INTO public."Dogovor"(dogovor_data_dogovora, dogovor_tip_dogovora, klient_id, kredit_id)
	VALUES ('2023-07-17', 'Тип договора 4', 4, 2);
INSERT INTO public."Dogovor"(dogovor_data_dogovora, dogovor_tip_dogovora, klient_id, kredit_id)
	VALUES ('2023-07-18', 'Тип договора 5', 5, 1);

