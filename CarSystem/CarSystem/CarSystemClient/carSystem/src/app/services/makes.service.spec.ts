import { TestBed } from '@angular/core/testing';

import { MakesService } from './makes.service';

describe('MakesService', () => {
  let service: MakesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MakesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
