# festiveKittenChallenge
This is by far one of the most frustrating projects I have ever worked on. My congratulations to the evil genius behind it. If I ever meet you, I will buy you a beer.

This project is a part challenge, part demonstration of my stubbornness and my ability to program. (maybe some Linux knowledge in there too.)

This is not a production-ready anything. It is the skeleton of what could be a nice app, but I ran out of the time needed to really make it fully functional, stable, and something people would be proud to have.

This product is CONFIDENTIAL, if you are neither myself, or one of the individuals evaluating me, then avert your eyes, this is not for you. 

Feel free to criticize it, but just know, this is my soul in code. So all of the glaring holes you find, will hurt me like you wouldn't believe.

## Installation
Assuming this will all run on your own system:
- I used VS 2019 Community Edition as my IDE. I feel if you already don't have a copy, [then go get one](https://visualstudio.microsoft.com/)
- I also used VS Code for the Vue App, because Visual Studio doesn't get on well with what I needed (So it's optional)
- You will also need npm [get it gere](https://nodejs.org/en/)
- and Docker
- and hyper-V, because Docker (on windows, but i don't know the requirements for other systems)

- Open the solution file with visual studio.
- As long as docker-compose is set as the startup item, it should all kick off when you hit F5
**Leave all build configurations on Debug! I didn't get everything working on Release**

- The Api Server should be running on https://localhost:5001

- Then PowerShell over to the project root of the ListeningPostWebUi project (from the repo root it's: /src/ListeningPostWebUi)
- Then just call
```PowerShell
npm run dev
```

- The Web UI should now be running on http://localhost:8080 (notice the non-TLS scheme)

### Caveats
You may need to copy a certificate from the root of this repository: *.pfx to C:\tmp (yes, i realize it's tmp instead of temp).
the docker container may need to read it to start correctly. If you need to trust it or something, the password is: "thisisnotasecurepassword" (minus quotes)