import { trigger, style, animate, transition, state } from '@angular/animations';

export const fadeIn = [
    trigger('fadeIn', [
        transition(':enter', [
            style({ opacity: 0 }),
            animate('3s ease-in-out', style({ opacity: 1 }))
        ])
    ])
];

export const fadeRight = [
    trigger('fadeRight', [
        state('default', style({
            opacity: 0,
            transform: 'translateX(-400px)'
        })),
        state('faded', style({
            opacity: 1
        })),
        transition('default => faded', [
            animate('1s ease-in-out')
        ])
    ])
];

export const fadeLeft = [
    trigger('fadeLeft', [
        state('default', style({
            opacity: 0,
            transform: 'translateX(400px)'
        })),
        state('faded', style({
            opacity: 1
        })),
        transition('default => faded', [
            animate('1s ease-in-out')
        ])
    ])
];

export const fadeUp = [
    trigger('fadeUp', [
        state('default', style({
            opacity: 0,
            transform: 'translateY(400px)'
        })),
        state('faded', style({
            opacity: 1
        })),
        transition('default => faded', [
            animate('1s ease-in-out')
        ])
    ])
];

export const fadeDown = [
    trigger('fadeDown', [
        state('default', style({
            opacity: 0,
            transform: 'translateY(-400px)'
        })),
        state('faded', style({
            opacity: 1
        })),
        transition('default => faded', [
            animate('1s ease-in-out')
        ])
    ])
];
