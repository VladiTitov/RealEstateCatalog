export interface IUserForLogin {
  username: string,
  password: string,
  token: string
}

export interface IUserForRegister {
  userName: string,
  email?: string;
  password: string;
  mobile?: number;
}
