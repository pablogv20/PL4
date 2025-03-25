# -*- coding: utf-8 -*-
import zeep

WSDL_URL = 'http://localhost:8733/Design_Time_Addresses/MathService/Math/?wsdl'

try:
    client = zeep.Client(WSDL_URL)
    number = int(input("Introduce un número para verificar si es primo: "))
    result = client.service.Prime(number)
    if result:
        print(f"El número {number} es primo.")
    else:
        print(f"El número {number} no es primo.")
except Exception as e:
    print(f"Error al invocar el servicio: {e}")


