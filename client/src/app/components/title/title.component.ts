import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  ngOnInit(): void {

    const greeting:string[] = ['Geeku', 'Be geeky', 'Be social', 'Be you'];
    let currentGreetingIndex: number = 0;
    let currentCharacterIndex: number = 0;
    let isDeleting: boolean = false;
    let isPaused: boolean = false;
    let pauseEnd: number = 0;

    function typeWriterEffect():any {
      const greetingElement:HTMLElement|null = document.getElementById('typing');

      if (!greetingElement) {
        console.error('Element with ID "typing" not found.');
        return;
      }
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
