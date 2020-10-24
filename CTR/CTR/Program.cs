using System;

namespace CTR
{
	class Program
	{
		public static void Main(string[] args)
		{
			string[] Salida={"0011","0100","0101","0110","0111","1001","1101","1111","1100","1110","1011","1011","1000","0001","0010","0000"};
			string mensaje="";
			string key="1011";
			string Ms_Parte1="";
			string Ms_Parte2="";
			int cont=0;
			string k_ms1="";
			string k_ms2="";
			
			
			Console.WriteLine("Ingrese un numero binario de 8 bits:");
			mensaje= Console.ReadLine();
			Verificar(mensaje,8);
			Console.WriteLine("Ingres un numero binario de 4 bits:");
			key= Console.ReadLine();
			Verificar(key,4);
			
			Ms_Parte1=mensaje.Substring(0,4);
			Ms_Parte2=mensaje.Substring(4,4);
			//Cuenta XOR (segunda parte del mensaje con la key)
			for (int z = key.Length-1;z>=0 ; z--) {
				for (int c = Ms_Parte2.Length-1; c >=0; c--) {
					if (cont<=key.Length) {
						if (key[z]==Ms_Parte2[c]) {
							k_ms2="0"+k_ms2;
							z--;
						}
						else{
							k_ms2="1"+k_ms2;	
							z--;
						}
					}
				}
			}
			
			//Cuenta XOR (primera parte del mensaje con la key)
			for (int z = key.Length-1;z>=0 ; z--) {
				for (int c = Ms_Parte1.Length-1; c >=0; c--) {
					if (cont<=key.Length) {
						if (key[z]==Ms_Parte1[c]) {
							k_ms1="0"+k_ms1;
							z--;
						}
						else{
							k_ms1="1"+k_ms1;	
							z--;
						}
					}
				}
			}
			Console.WriteLine("mi primer bloque es ");
			Console.WriteLine("Mi primer bloque es :"+k_ms1);
			Bin_a_Des(k_ms1,Salida);
			Console.WriteLine("\nMi segundo bloque es ");
			Console.WriteLine("Mi segundo bloque es :"+k_ms2 );
			Bin_a_Des(k_ms2,Salida);
			Console.ReadKey(true);
		}
		public static void Verificar(string Ms, int n){
			for (int x = Ms.Length-1 ; x >=0; x++) {
				if (Ms[x]=='0' || Ms[x]=='1') {
					if (Ms.Length<n) {
						Console.WriteLine("El mensaje es menor(tiene pocos bits)");
						Console.WriteLine("INGRESE EL DATO DE NUEVO");
						Ms=Console.ReadLine();
						Verificar(Ms,n);
					}
					if (Ms.Length==n) {
						Console.WriteLine("los datos son correctos\n-----------------------------");
						break;	
					}
					else{
						Console.WriteLine("El mensaje es mayor(tiene mas bits)");
						Console.WriteLine("INGRESE EL DATO DE NUEVO");
						Ms=Console.ReadLine();
						Verificar(Ms,n);
					}
				} 
				else{
					Console.WriteLine("El mensaje no es binario");
					Console.WriteLine("INGRESE EL DATO DE NUEVO");
					Ms=Console.ReadLine();
					Verificar(Ms,n);
					break;
				}
			}
		}
		
		public static void Bin_a_Des(string Ms, string[] salida){
			bool V=true;
			int i=0;
			string f="";
			
			for (int x = Ms.Length-1,y=0; x >=0; x--,y++) {
				if (Ms[x]=='0' || Ms[x]=='1') {
					i+=(int)(int.Parse(Ms[x].ToString()) * Math.Pow(2,y));
				}
				else{
					Console.WriteLine("El numero no es binario(Mensaje):");
					V=false;
					break;
				}
			}
			if (V) {
				//Console.WriteLine("El numero en decimal es: {0}",i);
				Console.WriteLine("La salida de la tabla es: "+salida[i]);
				
			}
		}
		

		
		
		
		
	}	
}