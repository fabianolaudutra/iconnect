import { Component } from '@angular/core';

interface Morador {
  name: string;
  age: number;
}

@Component({
  selector: 'app-morador',
  templateUrl: './morador.component.html',
  styleUrls: ['./morador.component.scss']
})
export class MoradorComponent {
  moradores: Morador[] = [];
  newMorador: Morador = { name: '', age: 0 };

  addMorador() {
    if (this.newMorador.name && this.newMorador.age) {
      this.moradores.push({ ...this.newMorador });
      this.newMorador = { name: '', age: 0 };
    }
  }

  editMorador(morador: Morador) {
    const index = this.moradores.indexOf(morador);
    if (index > -1) {
      const updatedMorador = { ...morador };
      this.moradores.splice(index, 1, updatedMorador);
    }
  }

  deleteMorador(morador: Morador) {
    const index = this.moradores.indexOf(morador);
    if (index > -1) {
      this.moradores.splice(index, 1);
    }
  }
}
