using System;

namespace Mac
{
	class Program
	{
		public static void Main(string[] args)
		{
			string Mensaje="";
			string Key="";
			string Ipad="1100";
			string Opad="1001";
			string K_Ipad="";
			string k_Opad="";
			int cont=0;
			
			
			Console.WriteLine("Ingrese un numero binario de 8 bits:");
			Mensaje= Console.ReadLine();
			Console.WriteLine("Ingres un numero binario de 4 bits:");
			Key= Console.ReadLine();
			
			//hace la cuentas de XOR(KEY XOR Ipad)
			for (int x = Key.Length-1; x>=0 ; x--) {
				for (int y = Ipad.Length-1; y >=0; y--) {
					if (cont<=Key.Length) {
						if (Key[x]==Ipad[y]) {
							K_Ipad="0"+K_Ipad;
							x--;
						}
						else{
							K_Ipad="1"+K_Ipad;	
							x--;
						}
					}
				}
			}
			//fin de la cuenta XOR(KEY xor Ipad)
			
			//Hace la cuentas XOR(KEY XOR Opad)			
			for (int z = Key.Length-1;z>=0 ; z--) {
				for (int c = Opad.Length-1; c >=0; c--) {
					if (cont<=Key.Length) {
						if (Key[z]==Opad[c]) {
							k_Opad="0"+k_Opad;
							z--;
						}
						else{
							k_Opad="1"+k_Opad;	
							z--;
						}
					}
				}
			}
			//fin de la cuenta XOR(KEY xor Opad)
			
			Bin_a_Des(K_Ipad+Mensaje,k_Opad);
			Console.ReadKey(true);
		}
		//------------------------------------
		public static void Bin_a_Des(string Ms,string k_Opad){
			bool V=true;
			int i=0;
			
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
				Console.WriteLine("El numero en decimal es: {0}",i);	
				Hash(i, k_Opad);	
			}
		}//combierte de binario a decimal
		//---------------------------------
		public static void Hash(int i, string k_Opad){
			int Resultado=0;
			//int cont=0;
			Resultado=(i*7)%13;
			Console.WriteLine("El numero hasheado es(En base 10):"+Resultado);
			Des_a_Bin(Resultado, k_Opad);
		}//hace el calculo del hash (a*7)mod 13
		//---------------------------------------------
		public static void Des_a_Bin(int Resultado, string k_Opad){
			string cifrado="";
			bool v=true;
			if (v) {
				while (Resultado > 0) {
				cifrado= Resultado%2+cifrado;
				Resultado= Resultado/2;
				}
				if (cifrado.Length<4) {
					Console.WriteLine("El Mensaje cifrado es: "+"0"+cifrado);
					cifrado="0"+cifrado;
					Console.WriteLine("\nSegunda parte");
					v=false;
					Bin_a_Des(k_Opad+cifrado,null);
				}
				else
					Console.WriteLine("El Mensaje cifrado es: "+cifrado);
					Console.WriteLine("Segunda parte");
					Bin_a_Des(k_Opad+cifrado,null);
				}
			else 
				Console.WriteLine("CIFRADO TERMINADO");
		}//combierte de decimal a binario
		//------------------------------
	}
}
