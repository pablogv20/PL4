# -*- coding: utf-8 -*-
import zeep

WSDL_URL = 'http://localhost:8733/Design_Time_Addresses/MathService/Math/'

try:
    client = zeep.Client(wsdl=WSDL_URL, service_name='MathService.Math', port_name='BasicHttpBinding_IMath')
    number = int(input("Introduce un n�mero para verificar si es primo: "))
    result = client.service.Prime(number)
    if result:
        print(f"El número {number} es primo.")
    else:
        print(f"El número {number} no es primo.")
except Exception as e:
    print(f"Error al invocar el servicio: {e}")


