import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Vehicle, VehicleStats, VehicleFilter } from '../models/vehicle.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private mockVehicles: Vehicle[] = [
    {
      id: '1',
      placa: 'AAA-0102',
      marca: 'Volkswagen',
      modelo: 'Golf',
      ano: 2018,
      cor: 'Branco',
      preco: 103900.00,
      temFotos: true,
      quantidadeFotos: 8,
      opcionais: 5,
      imagemUrl: 'https://via.placeholder.com/180x120/0066cc/ffffff?text=VW+Golf'
    },
    {
      id: '2',
      placa: 'BBB-1234',
      marca: 'Ford',
      modelo: 'Focus',
      ano: 2020,
      cor: 'Azul',
      preco: 85000.00,
      temFotos: true,
      quantidadeFotos: 12,
      opcionais: 8,
      imagemUrl: 'https://via.placeholder.com/180x120/cc6600/ffffff?text=Ford+Focus'
    },
    {
      id: '3',
      placa: 'CCC-5678',
      marca: 'Toyota',
      modelo: 'Corolla',
      ano: 2019,
      cor: 'Prata',
      preco: 95500.00,
      temFotos: false,
      quantidadeFotos: 0,
      opcionais: 3,
      imagemUrl: 'https://via.placeholder.com/180x120/666666/ffffff?text=No+Image'
    },
    {
      id: '4',
      placa: 'DDD-9876',
      marca: 'Honda',
      modelo: 'Civic',
      ano: 2021,
      cor: 'Preto',
      preco: 120000.00,
      temFotos: true,
      quantidadeFotos: 15,
      opcionais: 10,
      imagemUrl: 'https://via.placeholder.com/180x120/990000/ffffff?text=Honda+Civic'
    },
    {
      id: '5',
      placa: 'EEE-5432',
      marca: 'Chevrolet',
      modelo: 'Cruze',
      ano: 2017,
      cor: 'Vermelho',
      preco: 78900.00,
      temFotos: true,
      quantidadeFotos: 6,
      opcionais: 4,
      imagemUrl: 'https://via.placeholder.com/180x120/009900/ffffff?text=Chevrolet+Cruze'
    }
  ];

  constructor() { }

  getVehicles(): Observable<Vehicle[]> {
    return of(this.mockVehicles);
  }

  getVehicleStats(): Observable<VehicleStats> {
    const total = this.mockVehicles.length;
    const comFotos = this.mockVehicles.filter(v => v.temFotos).length;
    const semFotos = total - comFotos;

    return of({
      total: 110, // Valores da imagem
      comFotos: 80,
      semFotos: 30
    });
  }

  searchVehicles(filter: VehicleFilter): Observable<Vehicle[]> {
    // Implementar lógica de filtro aqui
    return of(this.mockVehicles);
  }
}
