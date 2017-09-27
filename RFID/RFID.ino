//https://create.arduino.cc/projecthub/Aritro/security-access-using-rfid-reader-f7c746
#include <SPI.h>
#include <MFRC522.h>

#include <NewliquidCrystal\LiquidCrystal_I2C.h>
#include <Wire.h>

#define SS_PIN 10
#define RST_PIN 9

LiquidCrystal_I2C lcd(0x27, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);

// Creates a MFRC522 instance.
MFRC522 mfrc522(SS_PIN, RST_PIN);

int led_green = 2;

int stopID = LOW;
int id = LOW;
int some = LOW;

byte A = 0;
byte D = 0;

long time;

void setup()
{
	Serial.begin(9600);   // Initiate a serial communication
	SPI.begin();      // Initiate  SPI bus
	mfrc522.PCD_Init();   // Initiate MFRC522
	//Serial.println("Approximate your card to the reader...");
	//Serial.println();

	pinMode(led_green, OUTPUT);

	display();
}

void loop()
{
	if (stopID == LOW)
	{
		if (millis() > time + 2000)
		{
			lcd.clear();
			id = LOW;
			digitalWrite(led_green, HIGH);
			lcd.print("Ready!");
			stopID = HIGH;
			some = LOW;
		}
	}	

	// Look for new cards
	if (!mfrc522.PICC_IsNewCardPresent())
	{
		return;
	}

	// Select one of the cards
	if (!mfrc522.PICC_ReadCardSerial())
	{
		return;
	}
	
	if (id == LOW)
	{
		for (byte i = 0; i < mfrc522.uid.size; i++)
		{
			Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? "0" : "");
			Serial.print(mfrc522.uid.uidByte[i], HEX);
			Serial.print(" ");
		}		
		stopID = LOW;
		time = millis();
		
		Serial.println();
		id = HIGH;
		digitalWrite(led_green, LOW);		
	}	
	access();
}

void display()
{
	lcd.begin(16, 2);
	lcd.setCursor(0, 0);
	lcd.print("  Hello World!");
	delay(1000);
	lcd.clear();
}

void access()
{
	//delay(500);
	byte a = 65;
	byte d = 68;

	byte outout = 0;
	
	outout = Serial.read();
		
	if (some == LOW)
	{
		if (outout == a)
		{
			lcd.clear();
			lcd.print("Authorized");
			lcd.setCursor(0, 1);
			lcd.print("access");
			some = HIGH;
		}

		if (outout == d)
		{
			lcd.clear();
			lcd.print("Access Denied");
			some = HIGH;
		}
	}	
}
