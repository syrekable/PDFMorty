# PDFMorty
A console application, letting you create a PDF with desired information
about various parts of *[Rick and Morty](https://www.rickandmorty.com/ "Official website")* universe.
## Usage
1. Provide a correct* password *(project requirement)*
2. Choose the main search category. Choose from:
	- character
	- location
	- episode
3. Choose among different settings shown on the screen.
4. Enjoy generated PDF with your desired trivia!

## Dependencies and resources
1. [Rick and Morty fan-made REST api](https://rickandmortyapi.com/)
2. [SimpleWebRequests... the name speaks for itself](https://www.nuget.org/packages/SimpleWebRequests/)
2. [Newtonsoft.Json package for dealing with json data](https://www.nuget.org/packages/newtonsoft.json/)
3. [PDFsharp-MigraDoc-GDI for creating PDFs easily *(hopefully...)*](https://nuget.org/packages/PDFsharp-MigraDoc-GDI)

### * The password should be checked for correctness
	- contain at least 8 characters, but no longer than 20 characters
	- contain at least one small and big letter
	- contains a letter
	- contain a special symbol, one of the (* . ,)
