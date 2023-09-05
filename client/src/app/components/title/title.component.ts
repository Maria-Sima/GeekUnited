import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  ngOnInit(): void {
    // Place the JavaScript code here
    const greeting:string[] = ['Bonjour', 'Hello', 'Buenos días', 'Guten Morgen'];
    let currentGreetingIndex = 0;
    let currentCharacterIndex = 0;
    let isDeleting = false;
    let isPaused = false;
    let pauseEnd = 0;

    function typeWriterEffect(): number {
      const greetingElement = document.getElementById('typing');

      if (isPaused && Date.now() > pauseEnd) {
        isPaused = false;
        if (isDeleting) {
          currentGreetingIndex = (currentGreetingIndex + 1) % greeting.length;
          isDeleting = false;
        } else {
          isDeleting = true;
        }
      }

      if (!isPaused && !isDeleting && currentCharacterIndex === greeting[currentGreetingIndex].length) {
        isPaused = true;
        pauseEnd = Date.now() + 800;
        return setTimeout(typeWriterEffect, 50);
      }

      if (!isPaused && isDeleting && currentCharacterIndex === 0) {
        isPaused = true;
        pauseEnd = Date.now() + 200;
        return setTimeout(typeWriterEffect, 50);
      }

      const timeout = isDeleting ? 100 : 200;
      greetingElement.innerText = greeting[currentGreetingIndex].substring(0, currentCharacterIndex);
      currentCharacterIndex = isDeleting ? currentCharacterIndex - 1 : currentCharacterIndex + 1;
      setTimeout(typeWriterEffect, timeout);
    }

    typeWriterEffect();
  }
}
