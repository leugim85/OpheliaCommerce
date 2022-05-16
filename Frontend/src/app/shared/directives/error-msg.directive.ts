import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[errorMsg]'
})
export class ErrorMsgDirective implements OnInit {
  element!: ElementRef<HTMLElement>;
  @Input() color: string = 'red';
  @Input() message: string = 'El campo es requerido';
  
  constructor(private el: ElementRef<HTMLElement>) {
    this.element = el;
   }
  ngOnInit(): void {
    this.setAttributes();
  }

  setAttributes() {
    this.element.nativeElement.style.color = this.color;
    this.element.nativeElement.textContent= this.message;
    this.element.nativeElement.classList.add('form-text')
    this.element.nativeElement.animate([
      { transform: 'translatex(-1px)' },
      { transform: 'translateY(-1px)' },
    ], {
      duration: 100,
      iterations: 5
    });
  }
}
