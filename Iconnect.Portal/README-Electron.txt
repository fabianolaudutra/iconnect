Todo prcoesso deve ser feito utilizando o PowerShell do windows, não é necessario a principio o modo administrador.

1. Rode o Preparar-ambiente.bat
	Este script ira instalar todo o necessario para realizar o Build

2. Por via das duvidas, instalar o .netcore runtime 3.1 

3. Altere o arquivo appsettings.json, colocando os valores iguais ao appsettings.Electron (Utilizar localhost:8001)

4. Altere o arquivo de envirnment.ts do projeto (Client) para utilizar tambem localhost:8001

3. Feito isso para gerar o instalador, dispare no visual studio o build com o nome "Electron.NET Build Windows"
	A primeira execução pode levar algum tempo, porem as demais são rapidas.

4. Após a finalização o instalador estara na pasta (RAIZ)\Iconnect.Portal\bin\Desktop\Iconnect.Portal Setup 1.0.0


Observações.
	Toda alteração de estrutura deve ser testada tambem no Electron para garantir que nao ira quebrar.
	