#include <UIPEthernet.h>
#include <utility/logging.h>

#define PORT 6666

#define BUFFER_SIZE 7

struct NtcValue
{
	double celcius;
	double resistance;
};
NtcValue ntcTable[] = {
{-40.0, 332093.6},
{-35.0, 239899.6},
{-30.0, 175199.6},
{-25.0, 129286.9},
{-20.0, 96358.2},
{-15.0, 72500.4},
{-10.0, 55045.9},
{-5.0, 42156.97},
{0.0, 32554.20},
{5.0, 25338.55},
{10.0, 19872.17},
{15.0, 15698.46},
{20.0, 12487.74},
{25.0, 10000.00},
{30.0, 8059.08},
{35.0, 6534.72},
{40.0, 5329.87},
{45.0, 4371.72},
{50.0, 3605.27},
{55.0, 2988.68},
{60.0, 2489.95},
{65.0, 2084.43},
{70.0, 1753.04},
{75.0, 1480.91},
{80.0, 1256.39},
{85.0, 1070.31},
{90.0, 915.42},
{95.0, 785.96},
{100.0, 677.30},
{105.0, 585.75},
{110.0, 508.32},
{115.0, 442.59},
{120.0, 386.60},
{125.0, 338.74},
};

uint8_t buf[BUFFER_SIZE];
EthernetUDP udp;
bool alarme = false;
int count = 0;
int countAlarmOn = 0;
int countAlarmOff = 0;
bool Intru = false;
bool Mouve = false;
bool IntruTest = false;
int mouvement;
double lumiere;
double temp;
int porte;
String s;
String mes;
double c1;
double c2;
double r1;
double r2;


double ResistanceToCelcius(double resistance)
{
	// Nombre d’elements dans le tableau de valeurs pour la conversion
	int count = sizeof(ntcTable) / sizeof(NtcValue);
	if (resistance >= ntcTable[0].resistance)
		return ntcTable[0].celcius;
	if (resistance <= ntcTable[count - 1].resistance)
		return ntcTable[count - 1].celcius;
	int idx = 0; // par défaut proche du premier élément
	double distance = abs(ntcTable[idx].resistance - resistance);
	for (int i = 1; i < count; i++)
	{
		double d = abs(ntcTable[i].resistance - resistance);
		if (d < distance)
		{
			idx = i;
			distance = d;
		}
	}
	double x = 0;
	if (ntcTable[idx].resistance > resistance)
	{
		c1 = ntcTable[idx].celcius;
		c2 = ntcTable[idx + 1].celcius;
		r1 = ntcTable[idx].resistance;
		r2 = ntcTable[idx + 1].resistance;
	}
	else if (ntcTable[idx].resistance < resistance)
	{
		c1 = ntcTable[idx].celcius;
		c2 = ntcTable[idx - 1].celcius;
		r1 = ntcTable[idx].resistance;
		r2 = ntcTable[idx - 1].resistance;
		// c = y r = x 
	}
	x = (((r2 - resistance) / (r2 - r1))*c1) + (((resistance - r1) / (r2 - r1))*c2);

	return x;
}
double ConvertTemperature(double rawValue)
{
	double value = 0;
	if (rawValue != 0)
	{
		// Convertir le voltage de rawValue (entre 0 et 1023 -> 0..5volt) en valeur de resistance
		value = 10000 / ((1023 / rawValue) - 1); // value est la valeur de la resistance du thermistor
		// Convertir resistance en valeur en degre celcius
		value = ResistanceToCelcius(value);
	}
	return value;
}


void ReplyUDP(uint8_t* buffer, int size) {
	int success = udp.beginPacket(udp.remoteIP(), udp.remotePort());

	int retry = 3;

	while (!success && retry > 0)
	{
		delay(10);
		--retry;
		success = udp.beginPacket(udp.remoteIP(), udp.remotePort());
	}
	udp.write(buffer, size);
	udp.endPacket();
}

void RetourMessage(char* message) {

	ReplyUDP((uint8_t*)message, strlen(message));
}

void setup() {
	//Mac Addresse
	uint8_t mac[6] = { 1, 2, 3, 4, 5, 6 };
	Ethernet.begin(mac, IPAddress(192, 168, 1, 50));
	Serial.begin(115200);
	pinMode(9, OUTPUT);
	pinMode(8, OUTPUT);
	pinMode(7, OUTPUT);
	pinMode(6, OUTPUT);
	pinMode(5, OUTPUT);
}

void loop() {
	mouvement = analogRead(A0);
	lumiere = (((1023.0 - analogRead(A1)) / 1023.0) * 100.0);
	temp = ConvertTemperature(analogRead(A2));
	porte = analogRead(A6);
	udp.begin(PORT);
	int packetSize = udp.parsePacket();
	if (packetSize != 0 && packetSize < BUFFER_SIZE)
	{
		udp.read((char*)buf, BUFFER_SIZE);
		mes = (char*)buf;

		if (mes.startsWith("D:"))
		{
			if (mes.length() > 2)
			{
				mes = mes.substring(0, 2);
			}
			uint8_t message[10];
			String s1 = HOST_NAME;
			s.concat(mes + s1);
			s.toCharArray((char*)message, 20);
			Serial.print((char*)message);
			RetourMessage((char*)message);
			s = "";
			mes = "";
			delay(1);
		}
		else if (mes.startsWith("U:"))
		{
			int pos1 = 0;

			pos1 += 2;

			int c1 = (mes.substring(pos1, pos1 + 2).toInt());
			pos1 += 2;
			int c2 = (mes.substring(pos1, pos1 + 2).toInt());

			switch (c1)
			{
			case 0:
				c1 = 9;
				break;
			case 1:
				c1 = 8;
				break;
			case 2:
				c1 = 7;
				break;
			case 3:
				c1 = 6;
				break;
			case 4:
				c1 = 5;
				break;
			case 5:
				c1 = 4;
				break;
			default:
				break;
			}

			if (c2 == 0)
			{
				digitalWrite(c1, c2);
			}
			else if (c2 == 1)
			{
				digitalWrite(c1, c2);
				if (c1 == 6)
				{
					IntruTest = true;
				}
			}
			RetourMessage("Ok");
			mes = "";
			s = "";
			delay(1);

		}
		else if (mes.startsWith("G:") && isDigit(mes.charAt(2)) == true && mes.length() < 3)
		{
			uint8_t message[10];
			switch (mes.substring(2, 3).toInt())
			{
			case 0:
				int i0 = 0;
				if (mouvement > 10)
				{
					i0 = 1;
				}
				s.concat(mes + ':' + i0);
				s.toCharArray((char*)message, 10);
				RetourMessage((char*)message);
				break;
			case 1:
				s.concat(mes + ':' + (int)lumiere);
				s.toCharArray((char*)message, 10);
				RetourMessage((char*)message);
				break;
			case 2:
				s.concat(mes + ':' + (int)temp);
				s.toCharArray((char*)message, 10);
				RetourMessage((char*)message);
				break;
			case 3:
				s.concat(mes + ':' + '-');
				s.toCharArray((char*)message, 10);
				RetourMessage((char*)message);
				break;
			case 4:
				int i1 = 0;
				if (porte > 10)
				{
					i1 = 1;
				}
				s.concat(mes + ':' + i1);
				s.toCharArray((char*)message, 10);
				RetourMessage((char*)message);
				break;
			case 5:
				s.concat(mes + ':' + '-');
				s.toCharArray((char*)message, 10);
				RetourMessage((char*)message);
				break;
			default:
				RetourMessage("rien");
				break;
			}
			s = "";
			mes = "";
			delay(1);

		}
		else if (mes.startsWith("G:A"))
		{
			if (mes.length() > 3)
			{
				mes = mes.substring(0, 3);
			}
			int i0 = 0;
			if (mouvement > 10)
			{
				i0 = 1;
			}
			int i1 = 0;
			if (porte > 10)
			{
				i1 = 1;
			}

			s.concat(mes + ':' + i0 + ':' + (int)lumiere + ':' + (int)temp + ':' + '-' + ':' + i1 + ':' + '-');

			uint8_t message[20];
			s.toCharArray((char*)message, 20);
			RetourMessage((char*)message);
			s = "";
			mes = "";
			delay(1);

		}
		else if (mes.startsWith("A:"))
		{
			alarme = true;
			RetourMessage("Ok");
			s = "";
			mes = "";
			delay(1);

		}
		else if (mes.startsWith("a:"))
		{
			alarme = false;
			Intru = false;
			IntruTest = false;
			RetourMessage("Ok");
			s = "";
			mes = "";
			delay(1);

		}
		udp.stop();
	}

	if (((alarme && mouvement > 10) || (alarme && porte > 10)) && Intru == false)
	{
		countAlarmOn = 200;
		Intru = true;
	}
	if (Intru == true && countAlarmOn > 0)
	{
		digitalWrite(6, HIGH);
		if (count <= 0 || countAlarmOff <= 0)
		{
			delay(5);
		}
		--countAlarmOn;
		if (countAlarmOn <= 0)
		{
			countAlarmOff = 200;
		}
	}
	if (Intru == true && countAlarmOff > 0)
	{
		digitalWrite(6, LOW);
		if (count <= 0 || countAlarmOn <= 0)
		{
			delay(5);
		}
		--countAlarmOff;
		if (countAlarmOff <= 0)
		{
			countAlarmOn = 200;
		}
	}
	if (Intru == false && IntruTest == false)
	{
		digitalWrite(6, LOW);
	}

	if (mouvement > 10)
	{
		Mouve = true;
		count = 2000;
	}
	if (count > 0)
	{
		digitalWrite(7, HIGH);
		if (Intru == false)
		{
			delay(5);
		}
		count--;
	}
	if (Mouve == true && count == 0)
	{
		Mouve = false;
		digitalWrite(7, LOW);
	}
	if ((lumiere < 20 && lumiere > 0) && mouvement > 10)
	{
		digitalWrite(8, HIGH);
	}
	Serial.print("Temp: ");
	Serial.print(temp);
	Serial.print(F("\t porte: "));
	Serial.print(porte);
	Serial.print(F("\t lumiere: "));
	Serial.print(lumiere);
	Serial.print(F("\t mouv: "));
	Serial.print(mouvement);
	Serial.print(F("\r\n"));
}
