export interface Vehicle {
  id: string;
  placa: string;
  marca: string;
  modelo: string;
  ano: number;
  cor: string;
  preco: number;
  temFotos: boolean;
  quantidadeFotos: number;
  opcionais: number;
  imagemUrl?: string;
}

export interface VehicleFilter {
  placa: string;
  marca: string;
  modelo: string;
  anoMin: number | null;
  anoMax: number | null;
  preco: string;
  fotos: string;
  opcionais: string;
  cor: string;
}

export interface VehicleStats {
  total: number;
  comFotos: number;
  semFotos: number;
}
