import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { VehicleService } from '../../services/vehicle.service';
import { Vehicle, VehicleStats, VehicleFilter } from '../../models/vehicle.model';

@Component({
  selector: 'app-vehicle-listing',
  templateUrl: './vehicle-listing.component.html',
  styleUrls: ['./vehicle-listing.component.css']
})
export class VehicleListingComponent implements OnInit {
  
  filterForm: FormGroup;
  vehicles: Vehicle[] = [];
  vehicleStats: VehicleStats = { total: 0, comFotos: 0, semFotos: 0 };
  
  currentPage = 1;
  pageSize = 1;
  
  marcas = ['Todos', 'Volkswagen', 'Ford', 'Chevrolet', 'Toyota', 'Honda'];
  precoOptions = ['Todos', '0 - 50.000', '50.000 - 100.000', '100.000+'];
  fotoOptions = ['Todos', 'Com fotos', 'Sem fotos'];
  opcionaisOptions = ['Todos', '0 - 5', '6 - 10', '11+'];
  corOptions = ['Todos', 'Branco', 'Preto', 'Prata', 'Azul', 'Vermelho'];

  constructor(
    private fb: FormBuilder,
    private vehicleService: VehicleService
  ) {
    this.filterForm = this.fb.group({
      placa: [''],
      marca: [''],
      modelo: [''],
      anoMin: [null],
      anoMax: [null],
      preco: ['Todos'],
      fotos: ['Todos'],
      opcionais: ['Todos'],
      cor: ['Todos']
    });
  }

  ngOnInit(): void {
    this.loadVehicles();
    this.loadStats();
  }

  loadVehicles(): void {
    this.vehicleService.getVehicles().subscribe(vehicles => {
      this.vehicles = vehicles;
    });
  }

  loadStats(): void {
    this.vehicleService.getVehicleStats().subscribe(stats => {
      this.vehicleStats = stats;
    });
  }

  onSearch(): void {
    const filter: VehicleFilter = this.filterForm.value;
    this.vehicleService.searchVehicles(filter).subscribe(vehicles => {
      this.vehicles = vehicles;
    });
  }

  onCadastrarVeiculo(): void {
    // Implementar lógica para cadastrar veículo
    console.log('Cadastrar veículo clicado');
  }

  onExportarEstoque(): void {
    // Implementar lógica para exportar estoque
    console.log('Exportar estoque clicado');
  }

  onSalvar(): void {
    // Implementar lógica para salvar
    console.log('Salvar clicado');
  }

  onEditarVeiculo(vehicle: Vehicle): void {
    // Implementar lógica para editar veículo
    console.log('Editar veículo:', vehicle);
  }

  onExcluirVeiculo(vehicle: Vehicle): void {
    // Implementar lógica para excluir veículo
    console.log('Excluir veículo:', vehicle);
  }
}
