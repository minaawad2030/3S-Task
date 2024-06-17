import { HttpInterceptorFn } from '@angular/common/http';
import { LoadingService } from '../services/loading.service';
import { finalize } from 'rxjs';
import { inject } from '@angular/core';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loader = inject(LoadingService);
  if (req.method == 'DELETE') return next(req);
  loader.busy();
  return next(req).pipe(
    finalize(() => {
      loader.idle();
    })
  );
};
