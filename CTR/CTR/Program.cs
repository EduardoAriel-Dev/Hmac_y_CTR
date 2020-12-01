using System;

namespace CTR
{
	class Program
	{
		public static void Main(string[] args)
		{
				//entrada   	0  ,   1  ,   2	 ,   3  ,   4  ,   5  ,  6   ,   7  ,  8   ,  9   ,  10  ,  11  ,  12  ,  13  ,  14  ,  15  	  
			string[] Salida={"0011","0100","0101","0110","0111","1001","1101","1111","1100","1110","1011","1011","1000","0001","0010","0000"};
			string mensaje="";
			string key="1011";
			string Ms_Parte1="";
			string Ms_Parte2="";
			string nose="01";
			string contador="00";
			string nose_cont=nose+contador;
			
			
			Console.WriteLine("Ingrese un numero binario de 8 bits:");
			mensaje= Console.ReadLine();
			Verificar(mensaje,8);
			Console.WriteLine("Ingres un numero binario de 4 bits:");
			key= Console.ReadLine();
			Verificar(key,4);
			
			Ms_Parte1=mensaje.Substring(0,4);
			Ms_Parte2=mensaje.Substring(4,4);
			
			//cifrado del primer mensaje
			Console.WriteLine("Mi primer bloque es ");
			Console.WriteLine("La primera parte del bloque es: "+Ms_Parte1);
			string x=cuenta_XoR(key,nose_cont);
			string y=Bin_a_Des(x,Salida);
			Console.WriteLine("Mi primer bloque cifrado es: "+cuenta_XoR(y,Ms_Parte1));
			Console.WriteLine("los datos son correctos\n-----------------------------");
			//Fin del Primer cifrado
			
			//Cifrado del segundo bloque
			Console.WriteLine("Mi segundo bloque es ");
			Console.WriteLine("La segunda parte del bloque es: "+Ms_Parte2);
			nose+=Contador(contador);//llamo al contador
			string z=cuenta_XoR(key,nose);
			string q=Bin_a_Des(z,Salida);
			Console.WriteLine("Mi segundo bloque cifrado es: "+cuenta_XoR(q,Ms_Parte2));
			Console.WriteLine("los datos son correctos\n-----------------------------");
			//Fin del Segundo cifrado
			
			
			

			Console.ReadKey(true);
		}
		
		public static string cuenta_XoR(string a,string b){
			int cont=0;
			string nose1="";
			for (int z = a.Length-1;z>=0 ; z--) {
				for (int c = b.Length-1; c >=0; c--) {
					if (cont<=a.Length) {
						if (a[z]==b[c]) {
							nose1="0"+nose1;
							z--;
						}
						else{
							nose1="1"+nose1;	
							z--;
						}
					}
				}
			}
			return nose1;
		}//Función de las cuentas XoR
		
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
		}//Verifica que los datos sean correctos
		
		public static string Bin_a_Des(string Ms, string[] salida){
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
				Console.WriteLine("La salida de la tabla es: "+salida[i]);
				f=salida[i];
			}
			return f;
		}//Pasa de Bits a Decimales
		
		public void des_a_bin(int Resultado){
		string cifrado="";
			bool v=true;
			if (v) {
				while (Resultado > 0) {
				cifrado= Resultado%2+cifrado;
				Resultado= Resultado/2;
				}	
			}
		}//Pasa de Decimales a Bits
		
		public static string Contador(string contador){
			String output = Convert.ToString(Convert.ToInt32(contador, 2), 10); 
			int result = Int32.Parse(output)+1;
			string binario = Convert.ToString(result, 2);
			if (binario=="01" | binario=="10" | binario=="00" | binario=="11") {
				return binario;
			}
			else
				return "0"+binario;
		}//Contador
		
	}	
}