export interface IPagination<TEntity> {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: TEntity[];
}